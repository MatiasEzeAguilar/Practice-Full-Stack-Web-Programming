using System;
using System.Net.Http.Headers;
using Backend.Data;
using Backend.Dtos.Auth;
using Backend.Helpers;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class AuthorRepository : IsAuthorRepository
{
    private readonly ApplicationContext _context;
    public AuthorRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Author> CreateAsync(Author authorModel)
    {
        await _context.Authors.AddAsync(authorModel);
        await _context.SaveChangesAsync();
        return authorModel;
    }

    public async Task<Author?> DeleteAsync(int id)
    {
        var authorModel = await _context.Authors.FirstOrDefaultAsync(x => x.IdAuthor == id);

        if (authorModel == null)
        {
            return null;
        }

        _context.Authors.Remove(authorModel);
        await _context.SaveChangesAsync();
        return authorModel;
    }

    public async Task<List<Author>> GetAllAsync(QueryObject query)
    {
        var authors = _context.Authors.Include(c => c.Series).AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
        {
            authors = authors.Where(s => s.AuthorName.Contains(query.Name));
        }

        return await authors.ToListAsync();

    }

    public async Task<Author?> GetIdAsync(int id)
    {
        return await _context.Authors.Include(c => c.Series).FirstOrDefaultAsync(i => i.IdAuthor == id);
    }

    public async Task<Author?> UpdateAsync(int id, UpdateAuthorRequestDto authorDto)
    {
        var existingAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.IdAuthor == id);

        if (existingAuthor == null)
        {
            return null;
        }

        existingAuthor.AuthorName = authorDto.AuthorName;
        existingAuthor.Birth = authorDto.Birth;
        existingAuthor.Nationality = authorDto.Nationality;

        await _context.SaveChangesAsync();
        return existingAuthor;
    }
}
