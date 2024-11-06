namespace GestionInventario.Models.Dto;

public class SupplierDto
{
    public required string Nit { get; set; }
    public required string Name { get; set; }
    public required string Phone { get; set; }
    public required string Address { get; set; }
}

public class SupplierUpdateDto
{
    public required string Phone { get; set; }
    public required string Address { get; set; }
}


