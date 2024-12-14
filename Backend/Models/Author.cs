using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

namespace Backend.Models;
public class Author
{
    [Key]
    [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdAuthor {get; set;}
    [Required]
    [MaxLength(30)]
    public string AuthorName {get; set;} = string.Empty;
    public DateTime Birth {get; set;}
    public string Nationality {get; set;} = string.Empty;
    [Required]
    public List<Series> Series {get; set;} = new List<Series>();
}