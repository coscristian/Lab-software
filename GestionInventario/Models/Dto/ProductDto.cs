namespace GestionInventario.Models.Dto;

public class ProductDto
{
    public string BarCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
     public string Category { get; set; }
    public string UnitMeasure { get; set; }
    public int SupplierId { get; set; }
}

public class ProductUpdateDto
{
    public string Name { get; set; }
    public bool Status { get; set; }
    public string Category { get; set; }
}