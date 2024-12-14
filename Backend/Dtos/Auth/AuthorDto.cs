using System;
using Backend.Dtos.Serie;
using Backend.Models;

namespace Backend.Dtos.Auth;

public class AuthorDto
{
    public int IdAuthor {get; set;}
    public string AuthorName {get; set;} = string.Empty;
    public DateTime Birth {get; set;}
    public string Nationality {get; set;} = string.Empty;
    public List<SeriesDto> Series {get; set;}
}