// File: SPC.Core/DTOs/Orders/OrderDto.cs
namespace SPC.Core.DTOs.Orders;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderItemDto> Items { get; set; }
}