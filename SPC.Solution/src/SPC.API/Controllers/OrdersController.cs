// Controllers/OrdersController.cs
using Microsoft.AspNetCore.Mvc;

namespace SPC.API.Controllers;

public class OrdersController : BaseApiController
{
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ILogger<OrdersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrders()
    {
        return Ok("Orders endpoint working!");
    }
}