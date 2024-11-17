using ErrorOr;

namespace GestionInventario.Errors.Products;

public static class ProductStatusErrors
{
    public static readonly Error Empty = 
        Error.Validation("Error.Empty", "Estado está vacío.");

    public static readonly Error InvalidStatus =
        Error.Validation("Error.InvalidStatus", "Estado invalido.");
}