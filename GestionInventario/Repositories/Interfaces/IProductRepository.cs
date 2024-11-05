using GestionInventario.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionInventario.Repositories.Interfaces;

public interface IProductRepository
{
    Task<bool> Add(Product product);
    Task<bool> ExistsProductById(int id);
    Task<bool> ExistsProductByBarCodeAsync(string barCode);
    Task<List<Product>> GetAllProducts();

    Task<bool> UpdateProduct(Product product);

    Task<Product?> GetProductById(int id);

    Task<bool> DeleteProduct(int id);

}