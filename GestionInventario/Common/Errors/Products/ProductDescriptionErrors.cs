using ErrorOr;

namespace GestionInventario.Errors.Products;

public static class ProductDescriptionErrors
{
    public static readonly Error Empty =
        Error.Validation("Description.Empty", "La descripción del producto está vacía");
    public static readonly Error InvalidMinimumLength =
        Error.Validation("Description.InvalidMinimumLength", "La descripción del producto es demasiado corta");
    public static readonly Error InvalidMaximumLength = 
        Error.Validation("Description.InvalidMaximumLength", "La descripción del producto es demasiado larga");
    public static readonly Error InvalidCharacters = 
        Error.Validation("Description.InvalidCharacters", "La descripción contiene caracteres no permitidos");
    public static readonly Error OnlyWhitespace = 
        Error.Validation("Description.OnlyWhitespace", "La descripción no puede contener solo espacios en blanco");
}