// File: SPC.Core/DTOs/Suppliers/CreateSupplierDto.cs
namespace SPC.Core.DTOs.Suppliers;

public class CreateSupplierDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}