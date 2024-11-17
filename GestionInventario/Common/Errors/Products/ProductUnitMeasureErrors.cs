using ErrorOr;

namespace GestionInventario.Errors.Products;

public static class ProductUnitMeasureErrors
{
    public static readonly Error Empty = 
        Error.Validation("UnitOfMeasure.Empty", "La unidad de medida está vacía");
    public static readonly Error InvalidUnit = 
        Error.Validation("UnitOfMeasure.InvalidUnit", "La unidad de medida no es válida");

}