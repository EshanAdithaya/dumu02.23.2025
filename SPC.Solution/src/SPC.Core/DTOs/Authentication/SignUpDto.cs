// File: SPC.Core/DTOs/Authentication/SignUpDto.cs
namespace SPC.Core.DTOs.Authentication;

public class SignUpDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}