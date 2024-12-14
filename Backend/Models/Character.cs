using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models;
public class Character
{
    [Key]
    [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCharacter {get; set;}
    [Required]
    [MaxLength(30)]
    public string CharName {get; set;} = string.Empty;
    [Required]
    [MaxLength(20)]
    public string Rol {get; set;} = string.Empty;
    [MaxLength(150)]
    public string CharSummary {get; set;} = string.Empty;
    [Required]
    public List<Series> Series {get; set;} = new List<Series>();
}
