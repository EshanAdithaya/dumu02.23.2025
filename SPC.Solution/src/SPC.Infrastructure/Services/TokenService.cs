using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SPC.Core.Entities;
using SPC.Core.Interfaces.Services;

namespace SPC.Infrastructure.Services;

public class TokenService : ITokenService
{
    // [Previous implementation remains the same]
}