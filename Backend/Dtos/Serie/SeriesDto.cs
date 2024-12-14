using System;
using Backend.Dtos.Auth;
using Backend.Dtos.Char;
using Backend.Dtos.Prod;
using Backend.Models;

namespace Backend.Dtos.Serie;

public class SeriesDto
{
    public int IdSeries {get; set;}
    public string Title {get; set;} = string.Empty;
    public string SeriesSummary {get; set;} = string.Empty;
    public DateTime Launch {get; set;}
    public List<AuthorDto> Author {get; set;}
    public List<ProducerDto> Producer {get; set;}
    public List<CharDto> Characters {get; set;}
}
