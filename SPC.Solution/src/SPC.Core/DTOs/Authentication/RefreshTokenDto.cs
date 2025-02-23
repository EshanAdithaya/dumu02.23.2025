using System.ComponentModel.DataAnnotations;

namespace SPC.Core.DTOs.Authentication;

public class RefreshTokenDto
{
    [Required]
    public string Token { get; set; }
}