using ErrorOr;

namespace GestionInventario.Errors.Products;

public static class ProductBarCodeErrors
{
    public static readonly Error Empty = Error.Validation("Barcode.Empty", "Código de barras está vacío");
    public static readonly Error InvalidLength = Error.Validation("Barcode.InvalidLength", "Longitud de código de barras inválida");
    public static readonly Error NonNumeric = Error.Validation("Barcode.NonNumeric", "Código de barras debe contener solo números");
    public static readonly Error Duplicate = Error.Validation("Barcode.Duplicate", "Código de barras ya existe");
}