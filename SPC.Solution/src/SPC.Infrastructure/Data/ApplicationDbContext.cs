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

        // Configure Supplier
        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.LicenseNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Address).HasMaxLength(500);
        });

        // Configure Drug
        modelBuilder.Entity<Drug>(entity =>
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.GenericName).HasMaxLength(200);
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
        });

        // Configure Stock
        modelBuilder.Entity<Stock>(entity =>
        {
            entity.Property(e => e.BatchNumber).IsRequired().HasMaxLength(50);
            entity.HasOne<Drug>()
                .WithMany()
                .HasForeignKey(s => s.DrugId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure Order
        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.PharmacyId).IsRequired().HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasPrecision(18, 2);
        });

        // Configure OrderItem
        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
            entity.Property(e => e.TotalPrice).HasPrecision(18, 2);
            entity.HasOne<Order>()
                .WithMany(o => o.OrderItems)  // Changed from Items to OrderItems
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<Drug>()
                .WithMany()
                .HasForeignKey(oi => oi.DrugId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}