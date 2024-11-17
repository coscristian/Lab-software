using ErrorOr;

namespace GestionInventario.Errors.Products;

public static class ProductNameErrors
{
    public static readonly Error Empty = 
        Error.Validation("Name.Empty", "Nombre está vacío");
    
    public static readonly Error InvalidCharacters = 
        Error.Validation("Name.InvalidCharacters", "Nombre contiene caracteres no permitidos");
    
    public static readonly Error InvalidMinimumLength =
        Error.Validation("Name.InvalidMinimumLength", "Longitud mínima de nombre invalida");
    
    public static readonly Error InvalidMaximumLength =
        Error.Validation("Name.InvalidMaximumLength", "Longitud máxima de nombre invalida");
    
    public static readonly Error MultipleConsecutiveSpaces = 
        Error.Validation("Name.MultipleConsecutiveSpaces", "Nombre contiene espacios consecutivos");
    
    public static readonly Error OnlyWhitespace = 
        Error.Validation("Name.OnlyWhitespace", "Nombre no puede contener solo espacios en blanco");
}