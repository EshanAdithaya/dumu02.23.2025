// File: SPC.Core/Entities/User.cs
using Microsoft.AspNetCore.Identity;

namespace SPC.Core.Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}