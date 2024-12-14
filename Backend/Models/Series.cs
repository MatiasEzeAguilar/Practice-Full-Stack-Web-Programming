using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models;
public class Series
{
    [Key]
    [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdSeries {get; set;}
    [Required]
    [MaxLength(70)]
    public string Title {get; set;} = string.Empty;
    [MaxLength(150)]
    public string SeriesSummary {get; set;} = string.Empty;
    public DateTime Launch {get; set;}
    [Required]
    public List<Author> Author {get; set;} = new List<Author>();
    public List<Producer> Producer {get; set;} = new List<Producer>();
    public List<Character> Characters {get; set;} = new List<Character>();
}
