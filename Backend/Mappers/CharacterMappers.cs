using System;
using Backend.Dtos.Char;
using Backend.Models;

namespace Backend.Mappers;

public static class CharacterMappers
{
    public static CharDto ToCharDto(this Character characterModel)
    {
        return new CharDto
        {
            IdCharacter = characterModel.IdCharacter,
            CharName = characterModel.CharName,
            Rol = characterModel.Rol,
            CharSummary = characterModel.CharSummary,
            Series = characterModel.Series.Select(c => c.ToSeriesDto()).ToList()
        };
    }
    
    public static Character ToCharFromCreateDto(this CreateCharRequestDto charDto)
    {
        return new Character
        {
            CharName = charDto.CharName,
            Rol = charDto.Rol,
            CharSummary = charDto.CharSummary
        };
    }
}
