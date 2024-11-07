using AutoMapper;
using GestionInventario.Controllers.Products;
using GestionInventario.Models;
using GestionInventario.Models.Dto;
using GestionInventario.Models.Enums;
using GestionInventario.Repositories.Interfaces;
using GestionInventario.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace GestionInventario.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<bool> CreateProduct(ProductDto product)
    {
        try
        {
            var existsProduct = await _productRepository.ExistsProductByBarCodeAsync(product.BarCode);
            if (existsProduct)
                return false;

            var mappedProduct = _mapper.Map<ProductDto, Product>(product);
            mappedProduct.Status = true;
            mappedProduct.CreationDate = DateTime.Now;
            mappedProduct.ModificationDate = DateTime.Now;
            mappedProduct.MotivoEstado = string.Empty;

            var result = await _productRepository.Add(mappedProduct);
            return result;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<List<Product>> GetAllProducts(string? name, string? category)
    {
        return await _productRepository.GetAllProducts(name, category);
    }



    public async Task<bool> ExistsProductById(int id)
    {
        return await _productRepository.ExistsProductById(id);

    }

    public async Task<Product?> GetProductById(int id)
    {
        return await _productRepository.GetProductById(id);
    }

    public async Task<bool> UpdateProduct(int id, ProductUpdateDto updatedProductDto)
    {
        // Obtener el producto existente del repositorio
        Product? existingProduct = await _productRepository.GetProductById(id);

        // Si el producto no existe, retorna false
        if (existingProduct == null)
        {
            return false;
        }

        existingProduct.Name = updatedProductDto.Name;
        //existingProduct.UnitPrice = updatedProductDto.UnitPrice;
        existingProduct.Status = updatedProductDto.Status;
        existingProduct.Category = updatedProductDto.Category;

        return await _productRepository.UpdateProduct(existingProduct);
    }

    public async Task<bool> Update(Product product)
    {
        return await _productRepository.UpdateProduct(product);
    }

    public async Task<bool> UpdateProductStatus(int id)
    {
        var product = await _productRepository.GetProductById(id);
        if(product is null)
        {
            return false;
        }

        product.Status = false;
        return await _productRepository.UpdateProduct(product);
    }

}