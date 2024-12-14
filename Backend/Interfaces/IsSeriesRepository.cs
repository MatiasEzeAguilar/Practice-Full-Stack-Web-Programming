using System;
using Backend.Dtos.Serie;
using Backend.Helpers;
using Backend.Models;

namespace Backend.Interfaces;

public interface IsSeriesRepository
{
    Task<List<Series>> GetAllAsync(QueryObject query);
    Task<Series?> GetIdAsync(int id);
    Task<Series> CreateAsync(Series seriesModel);
    Task<Series?> UpdateAsync(int id, UpdateSeriesRequestDto seriesDto);
    Task<Series?> DeleteAsync(int id);
}
