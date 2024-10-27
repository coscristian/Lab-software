using GestionInventario.Models.Dto;

namespace GestionInventario.Services.Interfaces;

public interface IProductService
{
    Task<bool> CreateProduct(ProductDto product);
}