// File: SPC.Core/DTOs/Authentication/AuthResponseDto.cs
namespace SPC.Core.DTOs.Authentication;

public class AuthResponseDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string Email { get; set; }
    public int UserId { get; set; }
    public List<string> Roles { get; set; }
}