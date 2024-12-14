using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Serie;

public class CreateSeriesRequestDto
{
    [Required]
    [MaxLength(70, ErrorMessage = "Title cannot be more than 70 characters.")]
    public string Title {get; set;} = string.Empty;
    [Required]
    [MaxLength(150, ErrorMessage = "Summary cannot be more than 150 characters.")]
    public string SeriesSummary {get; set;} = string.Empty;
    public DateTime Launch {get; set;}
}
