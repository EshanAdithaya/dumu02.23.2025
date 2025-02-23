// File: SPC.Core/DTOs/Orders/CreateOrderDto.cs
namespace SPC.Core.DTOs.Orders;

public class CreateOrderDto
{
    public List<CreateOrderItemDto> Items { get; set; }
}