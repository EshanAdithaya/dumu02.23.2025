// SPC.Infrastructure/Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using SPC.Core.Entities;

namespace SPC.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Drug> Drugs { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure your entity relationships and constraints here
        modelBuilder.Entity<OrderItem>()
            .HasOne<Order>()
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<Stock>()
            .HasOne<Drug>()
            .WithMany()
            .HasForeignKey(s => s.DrugId);
    }
}