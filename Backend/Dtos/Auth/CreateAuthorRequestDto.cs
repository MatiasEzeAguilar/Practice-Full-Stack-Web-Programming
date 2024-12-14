using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Auth;

public class CreateAuthorRequestDto
{
    [Required]
    [MaxLength(30, ErrorMessage = "Author Name cannot be more than 30 characters.")]
    public string AuthorName {get; set;} = string.Empty;
    public DateTime Birth {get; set;}
    public string Nationality {get; set;} = string.Empty;
}
