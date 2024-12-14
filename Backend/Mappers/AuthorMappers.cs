using System;
using Backend.Dtos.Auth;
using Backend.Models;

namespace Backend.Mappers;

public static class AuthorMappers
{
    public static AuthorDto ToAuthorDto(this Author authorModel)
    {
        return new AuthorDto
        {
            IdAuthor = authorModel.IdAuthor,
            AuthorName = authorModel.AuthorName,
            Birth = authorModel.Birth,
            Nationality = authorModel.Nationality,
            Series = authorModel.Series.Select(c => c.ToSeriesDto()).ToList()
        };
    }
    public static Author ToAuthorFromCreateDto(this CreateAuthorRequestDto authorDto)
    {
        return new Author
        {
            AuthorName = authorDto.AuthorName,
            Birth = authorDto.Birth,
            Nationality = authorDto.Nationality
        };
    }
}
