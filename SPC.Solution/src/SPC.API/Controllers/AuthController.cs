using Microsoft.AspNetCore.Mvc;
using SPC.Core.DTOs.Authentication;
using SPC.Core.Interfaces.Services;

namespace SPC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(
        IAuthService authService, 
        ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    // [Previous implementation remains the same]
}