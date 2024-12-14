using System;
using Backend.Dtos.Auth;
using Backend.Helpers;
using Backend.Models;

namespace Backend.Interfaces;

public interface IsAuthorRepository
{
    Task<List<Author>> GetAllAsync(QueryObject query);
    Task<Author?> GetIdAsync(int id);
    Task<Author> CreateAsync(Author authorModel);
    Task<Author?> UpdateAsync(int id, UpdateAuthorRequestDto authorDto);
    Task<Author?> DeleteAsync(int id);
}