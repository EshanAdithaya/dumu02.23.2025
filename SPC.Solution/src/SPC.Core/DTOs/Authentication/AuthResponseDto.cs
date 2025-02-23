namespace SPC.Core.DTOs.Authentication;

public class AuthResponseDto
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string Role { get; set; }
}