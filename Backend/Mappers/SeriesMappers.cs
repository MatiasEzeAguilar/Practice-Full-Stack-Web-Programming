using System;
using Backend.Dtos.Serie;
using Backend.Models;

namespace Backend.Mappers;

public static class SeriesMappers
{
    public static SeriesDto ToSeriesDto(this Series seriesModel)
    {
        return new SeriesDto
        {
            IdSeries = seriesModel.IdSeries,
            Title = seriesModel.Title,
            SeriesSummary = seriesModel.SeriesSummary,
            Launch = seriesModel.Launch,
            Author = seriesModel.Author.Select(c => c.ToAuthorDto()).ToList(),
            Producer = seriesModel.Producer.Select(c => c.ToProducerDto()).ToList(),
            Characters = seriesModel.Characters.Select(c => c.ToCharDto()).ToList()
        };
    }

    public static Series ToSeriesFromCreateDto(this CreateSeriesRequestDto seriesDto)
    {
        return new Series
        {
            Title = seriesDto.Title,
            SeriesSummary = seriesDto.SeriesSummary,
            Launch = seriesDto.Launch
        };
    }
}
