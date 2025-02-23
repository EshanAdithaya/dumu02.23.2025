// File: SPC.Core/DTOs/Orders/OrderItemDto.cs
namespace SPC.Core.DTOs.Orders;

public class OrderItemDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int DrugId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
