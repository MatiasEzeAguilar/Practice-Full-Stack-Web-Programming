using System;
using Backend.Dtos.Char;
using Backend.Helpers;
using Backend.Models;

namespace Backend.Interfaces;

public interface IsCharacterRepository
{
    Task<List<Character>> GetAllAsync(QueryObject query);
    Task<Character?> GetIdAsync(int id);
    Task<Character> CreateAsync(Character characterModel);
    Task<Character?> UpdateAsync(int id, UpdateCharRequestDto characterDto);
    Task<Character?> DeleteAsync(int id);
}
