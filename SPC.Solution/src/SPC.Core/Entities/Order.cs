// SPC.Core/Entities/Order.cs
namespace SPC.Core.Entities;

public class Order
{
    public int Id { get; set; }
    public string PharmacyId { get; set; } = string.Empty;
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public object OrderItems { get; set; }
}