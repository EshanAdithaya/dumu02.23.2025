using SPC.Core.Enums;

namespace SPC.Core.DTOs.Order;

public class OrderDto
{
    public int Id { get; set; }
    public string PharmacyId { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
}