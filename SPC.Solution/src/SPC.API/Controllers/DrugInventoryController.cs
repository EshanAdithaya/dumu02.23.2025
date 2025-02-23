// Controllers/DrugInventoryController.cs
using Microsoft.AspNetCore.Mvc;

namespace SPC.API.Controllers;

public class DrugInventoryController : BaseApiController
{
    private readonly ILogger<DrugInventoryController> _logger;

    public DrugInventoryController(ILogger<DrugInventoryController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetInventory()
    {
        return Ok("Drug inventory endpoint working!");
    }
}