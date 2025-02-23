using SPC.Core.Entities;

namespace SPC.Core.Interfaces.Services;

public interface ITokenService
{
    string GenerateJwtToken(User user);
    string GenerateRefreshToken();
}