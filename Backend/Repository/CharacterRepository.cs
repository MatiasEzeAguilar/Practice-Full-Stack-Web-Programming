using System;
using Backend.Data;
using Backend.Dtos.Char;
using Backend.Helpers;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class CharacterRepository : IsCharacterRepository
{
    private readonly ApplicationContext _context;
    public CharacterRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Character> CreateAsync(Character characterModel)
    {
        await _context.Characters.AddAsync(characterModel);
        await _context.SaveChangesAsync();
        return characterModel;
    }

    public async Task<Character?> DeleteAsync(int id)
    {
        var characterModel = await _context.Characters.FirstOrDefaultAsync(x => x.IdCharacter == id);

        if (characterModel == null)
        {
            return null;
        }

        _context.Characters.Remove(characterModel);
        await _context.SaveChangesAsync();
        return characterModel;
    }

    public async Task<List<Character>> GetAllAsync(QueryObject query)
    {
        var characters = _context.Characters.Include(c => c.Series).AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
        {
            characters = characters.Where(s => s.CharName.Contains(query.Name));
        }

        return await characters.ToListAsync();
    }

    public async Task<Character?> GetIdAsync(int id)
    {
        return await _context.Characters.Include(c => c.Series).FirstOrDefaultAsync(i => i.IdCharacter == id);
    }

    public async Task<Character?> UpdateAsync(int id, UpdateCharRequestDto characterDto)
    {
        var existingChar = await _context.Characters.FirstOrDefaultAsync(x => x.IdCharacter == id);

        if (existingChar == null)
        {
            return null;
        }

        existingChar.CharName = characterDto.CharName;
        existingChar.CharSummary = characterDto.CharSummary;
        existingChar.Rol = characterDto.Rol;

        await _context.SaveChangesAsync();
        return existingChar;
    }
}