using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models;
public class Producer
{
    [Key]
    [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdProducer {get; set;}
    [Required]
    [MaxLength(30)]
    public string ProducerName {get; set;} = string.Empty;
    public DateTime Foundation {get; set;}
    [Required]
    public List<Series> Series {get; set;} = new List<Series>(); 
}
