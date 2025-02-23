// File: SPC.Core/DTOs/Orders/CreateOrderItemDto.cs
namespace SPC.Core.DTOs.Orders;

public class CreateOrderItemDto
{
    public int DrugId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}