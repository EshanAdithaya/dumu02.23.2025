// Controllers/SuppliersController.cs
using Microsoft.AspNetCore.Mvc;

namespace SPC.API.Controllers;

public class SuppliersController : BaseApiController
{
    private readonly ILogger<SuppliersController> _logger;

    public SuppliersController(ILogger<SuppliersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSuppliers()
    {
        return Ok("Suppliers endpoint working!");
    }
}