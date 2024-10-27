using GestionInventario.Models;

namespace GestionInventario.Repositories.Interfaces;

public interface IProductRepository
{
    Task<bool> Add(Product product);
    Task<bool> ExistsProductById(int id);
    Task<bool> ExistsProductByBarCodeAsync(string barCode);

}