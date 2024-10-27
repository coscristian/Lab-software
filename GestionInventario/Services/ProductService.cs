using AutoMapper;
using GestionInventario.Models;
using GestionInventario.Models.Dto;
using GestionInventario.Models.Enums;
using GestionInventario.Repositories.Interfaces;
using GestionInventario.Services.Interfaces;

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
            //mappedProduct.Status = Status.Active;
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
}