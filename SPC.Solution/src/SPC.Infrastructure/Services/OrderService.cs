using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SPC.Core.DTOs.Order;
using SPC.Core.Entities;
using SPC.Core.Interfaces.Services;
using SPC.Infrastructure.Data;

namespace SPC.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public OrderService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<OrderDto>> GetAllOrdersAsync(int page = 1, int pageSize = 10)
    {
        var orders = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Drug)
            .OrderByDescending(o => o.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return _mapper.Map<List<OrderDto>>(orders);
    }

    public async Task<OrderDto> GetOrderByIdAsync(int id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Drug)
            .FirstOrDefaultAsync(o => o.Id == id);

        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> CreateOrderAsync(CreateOrderDto orderDto)
    {
        // Validate drug availability and calculate total amount
        var orderItems = new List<OrderItem>();
        decimal totalAmount = 0;

        foreach (var item in orderDto.OrderItems)
        {
            var drug = await _context.Drugs.FindAsync(item.DrugId);
            if (drug == null)
                throw new ArgumentException($"Drug with ID {item.DrugId} not found");

            var orderItem = new OrderItem
            {
                DrugId = item.DrugId,
                Quantity = item.Quantity,
                UnitPrice = drug.UnitPrice,
                TotalPrice = drug.UnitPrice * item.Quantity
            };

            orderItems.Add(orderItem);
            totalAmount += orderItem.TotalPrice;
        }

        var order = new Order
        {
            PharmacyId = orderDto.PharmacyId,
            Status = Enums.OrderStatus.Pending,
            TotalAmount = totalAmount,
            CreatedAt = DateTime.UtcNow,
            OrderItems = orderItems
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> UpdateOrderStatusAsync(int id, UpdateOrderStatusDto statusDto)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
            return null;

        order.Status = statusDto.Status;
        order.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return _mapper.Map<OrderDto>(order);
    }

    public async Task<bool> CancelOrderAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
            return false;

        order.Status = Enums.OrderStatus.Cancelled;
        order.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }
}