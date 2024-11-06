namespace GestionInventario.Models;

public class Supplier : Entity
{        
    public string Nit { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    //public ICollection<Product> Products { get; set; }
}