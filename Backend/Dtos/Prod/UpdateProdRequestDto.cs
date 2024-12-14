using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Prod;

public class UpdateProdRequestDto
{
    [Required]
    [MaxLength(30, ErrorMessage = "Producer Name cannot be more than 30 characters.")]
    public string ProducerName {get; set;} = string.Empty;
    public DateTime Foundation {get; set;}
}
