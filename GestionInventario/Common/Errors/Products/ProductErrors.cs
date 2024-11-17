using ErrorOr;

namespace GestionInventario.Errors.Products;

public static class ProductErrors
{
    public static Error NotFound(int id) =>
        Error.NotFound("Product.NotFound", $"El producto con Id {id} no fue encontrado");

    public static Error NotFoundByName(string name) =>
        Error.NotFound("Product.NotFound", $"El producto con nombre {name} no fue encontrado");
    
    public static Error DuplicateId(int id) =>
        Error.Conflict("Product.DuplicateId", $"El producto con Id {id} no es único, ya existe");
}