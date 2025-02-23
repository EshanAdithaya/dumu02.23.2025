using System.ComponentModel.DataAnnotations;

namespace SPC.Core.DTOs.Authentication;

public class SignUpDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Username { get; set; }

    [Required]
    [MinLength(8)]
    public string Password { get; set; }

    [Required]
    public string Role { get; set; }
}