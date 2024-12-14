using System;
using Backend.Dtos.Prod;
using Backend.Models;

namespace Backend.Mappers;

public static class ProducerMappers
{
    public static ProducerDto ToProducerDto(this Producer producerModel)
    {
        return new ProducerDto
        {
            IdProducer = producerModel.IdProducer,
            ProducerName = producerModel.ProducerName,
            Foundation = producerModel.Foundation,
            Series = producerModel.Series.Select(c => c.ToSeriesDto()).ToList()
        };
    }

    public static Producer ToProdFromCreateDto(this CreateProducerRequestDto prodcerDto)
    {
        return new Producer
        {
            ProducerName = prodcerDto.ProducerName,
            Foundation = prodcerDto.Foundation
        };
    }
}
