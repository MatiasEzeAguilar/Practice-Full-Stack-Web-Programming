using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Char;

public class CreateCharRequestDto
{
    [Required]
    [MaxLength(30, ErrorMessage = "Character Name cannot be more than 30 characters.")]
    public string CharName {get; set;} = string.Empty;
    [Required]
    [MaxLength(20, ErrorMessage = "Rol cannot be more than 20 characters.")]
    public string Rol {get; set;} = string.Empty;
    [MaxLength(150, ErrorMessage = "Summary cannot be more than 150 characters.")]
    public string CharSummary {get; set;} = string.Empty;
}