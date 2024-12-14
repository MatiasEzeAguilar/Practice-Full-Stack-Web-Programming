using System;
using Backend.Dtos.Serie;
using Backend.Models;

namespace Backend.Dtos.Prod;

public class ProducerDto
{
    public int IdProducer {get; set;}
    public string ProducerName {get; set;} = string.Empty;
    public DateTime Foundation {get; set;}
    public List<SeriesDto> Series {get; set;}
}
