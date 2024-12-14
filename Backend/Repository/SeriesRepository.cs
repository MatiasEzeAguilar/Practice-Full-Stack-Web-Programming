using System;
using Backend.Data;
using Backend.Dtos.Serie;
using Backend.Helpers;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository;

public class SeriesRepository : IsSeriesRepository
{
    private readonly ApplicationContext _context;
    public SeriesRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Series> CreateAsync(Series seriesModel)
    {
        await _context.Series.AddAsync(seriesModel);
        await _context.SaveChangesAsync();
        return seriesModel;
    }

    public async Task<Series?> DeleteAsync(int id)
    {
        var seriesModel = await _context.Series.FirstOrDefaultAsync(x => x.IdSeries == id);

        if (seriesModel == null)
        {
            return null;
        }

        _context.Series.Remove(seriesModel);
        await _context.SaveChangesAsync();
        return seriesModel;
    }

    public async Task<List<Series>> GetAllAsync(QueryObject query)
    {
        var series = _context.Series.Include(c => c.Author).Include(c => c.Producer).Include(c => c.Characters).AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
        {
            series = series.Where(s => s.Title.Contains(query.Name));
        }

        return await series.ToListAsync();
    }

    public async Task<Series?> GetIdAsync(int id)
    {
        return await _context.Series.Include(c => c.Author).Include(c => c.Producer).Include(c => c.Characters).FirstOrDefaultAsync(i => i.IdSeries == id);
    }

    public async Task<Series?> UpdateAsync(int id, UpdateSeriesRequestDto seriesDto)
    {
        var existingSeries = await _context.Series.FirstOrDefaultAsync(x => x.IdSeries == id);

        if (existingSeries == null)
        {
            return null;
        }

        existingSeries.Title = seriesDto.Title;
        existingSeries.SeriesSummary = seriesDto.SeriesSummary;
        existingSeries.Launch = seriesDto.Launch;

        await _context.SaveChangesAsync();
        return existingSeries;
    }
}
