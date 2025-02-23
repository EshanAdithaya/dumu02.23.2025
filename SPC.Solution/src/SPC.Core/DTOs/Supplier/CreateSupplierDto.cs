using System.ComponentModel.DataAnnotations;
using SPC.Core.Enums;

namespace SPC.Core.DTOs.Supplier;

public class CreateSupplierDto
{
    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string LicenseNumber { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [Phone]
    [StringLength(20)]
    public string Phone { get; set; }

    [Required]
    [StringLength(500)]
    public string Address { get; set; }

    public SupplierStatus Status { get; set; } = SupplierStatus.Active;
}