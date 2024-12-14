using System;
using Backend.Data;
using Backend.Dtos.Prod;
using Backend.Helpers;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class ProducerRepository : IsProducerRepository
{
    private readonly ApplicationContext _context;
    public ProducerRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Producer> CreateAsync(Producer producerModel)
    {
        await _context.Producers.AddAsync(producerModel);
        await _context.SaveChangesAsync();
        return producerModel;
    }

    public async Task<Producer?> DeleteAsync(int id)
    {
        var producerModel = await _context.Producers.FirstOrDefaultAsync(x => x.IdProducer == id);

        if (producerModel == null)
        {
            return null;
        }

        _context.Producers.Remove(producerModel);
        await _context.SaveChangesAsync();
        return producerModel;
    }

    public async Task<List<Producer>> GetAllAsync(QueryObject query)
    {
        var producers = _context.Producers.Include(c => c.Series).AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
        {
            producers = producers.Where(s => s.ProducerName.Contains(query.Name));
        }

        return await producers.ToListAsync();
    }

    public async Task<Producer?> GetIdAsync(int id)
    {
        return await _context.Producers.Include(c => c.Series).FirstOrDefaultAsync(i => i.IdProducer == id);
    }

    public async Task<Producer?> UpdateAsync(int id, UpdateProdRequestDto producerDto)
    {
        var existingProducer = await _context.Producers.FirstOrDefaultAsync(x => x.IdProducer == id);

        if (existingProducer == null)
        {
            return null;
        }

        existingProducer.ProducerName = producerDto.ProducerName;
        existingProducer.Foundation = producerDto.Foundation;

        await _context.SaveChangesAsync();
        return existingProducer;
    }
}
