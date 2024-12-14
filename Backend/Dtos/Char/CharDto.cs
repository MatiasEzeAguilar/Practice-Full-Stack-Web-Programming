using System;
using Backend.Dtos.Serie;
using Backend.Models;

namespace Backend.Dtos.Char;

public class CharDto
{
    public int IdCharacter {get; set;}
    public string CharName {get; set;} = string.Empty;
    public string Rol {get; set;} = string.Empty;
    public string CharSummary {get; set;} = string.Empty;
    public List<SeriesDto> Series {get; set;}
}
