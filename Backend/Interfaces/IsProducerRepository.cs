using System;
using Backend.Dtos.Prod;
using Backend.Helpers;
using Backend.Models;

namespace Backend.Interfaces;

public interface IsProducerRepository
{
    Task<List<Producer>> GetAllAsync(QueryObject query);
    Task<Producer?> GetIdAsync(int id);
    Task<Producer> CreateAsync(Producer producerModel);
    Task<Producer?> UpdateAsync(int id, UpdateProdRequestDto producerDto);
    Task<Producer?> DeleteAsync(int id);
}
