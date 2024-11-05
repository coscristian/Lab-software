namespace GestionInventario.Models;

public class Product : Entity
{
    public string BarCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal UnitPrice { get; set; }
    public string UnitMeasure { get; set; }
    public int Stock { get; set; }

   
}