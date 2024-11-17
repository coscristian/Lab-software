using System.Net;
using AutoMapper;
using GestionInventario.Models.Dto;
using GestionInventario.Repositories.Interfaces;
using GestionInventario.Services.Interfaces;
using ErrorOr;
using GestionInventario.Common.Responses;
using GestionInventario.Common.Responses.Dto;
using GestionInventario.Errors.Products;
using Product = GestionInventario.Common.Validations.Products.Product;

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

    public async Task<ErrorOr<Response<ProductResponseDto>>> CreateProduct(ProductDto productDto)
    {
        try
        {
            var errors = ValidateProductCreation(productDto); // TODO: Change productDtoName to productRequestDto
            if (errors.Count > 0)
            {
                return errors;
            }

            var productResponse = new ProductResponseDto() { };
            return Response<ProductResponseDto>.SuccessCreation(
                "Creación de Producto existosa",
                productResponse,
                HttpStatusCode.OK
            );

            // var existsProduct = await _productRepository.ExistsProductByBarCodeAsync(productDto.BarCode);
            // if (existsProduct)
            //     return false;
            //
            // var mappedProduct = _mapper.Map<ProductDto, Models.Product>(productDto);
            // var result = await _productRepository.Add(mappedProduct);
            // return result;
        }
        catch (Exception e)
        {
            var productResponse = new ProductResponseDto() { };
            return Response<ProductResponseDto>.SuccessCreation(
                "Creación de Producto existosa",
                productResponse,
                HttpStatusCode.OK
            );
        }
    }

    private static List<Error> ValidateProductCreation(ProductDto productDto)
    {
        // ProblemDetails problemDetails = new ProblemDetails()
        // {
        //     Title = "Error en la validación de los datos",
        //     Detail = "Los parametros no son correctos",
        //     Status = 400,
        //     Type = "https://example.com/code-error-1"
        // };
        var errors = new List<Error>();
        ValidateProductName(productDto.Name, errors);

        return errors;
        
        
        
        //if (string.IsNullOrEmpty(productDto.Name)) Errors.Add(ProductNameErrors.Empty);
        //if (string.IsNullOrEmpty(productDto.BarCode)) Errors.Add(ProductBarCodeErrors.Empty);
        

    }

    private static void ValidateProductName(string name, List<Error> errors)
    {
        if (string.IsNullOrEmpty(name))
            errors.Add(ProductNameErrors.Empty);
        
        if (!Product.Name.AreValidCharacters(name))
            errors.Add(ProductNameErrors.InvalidCharacters);

        if (!Product.Name.IsValidMinimumLength(name))
            errors.Add(ProductNameErrors.InvalidMinimumLength);
        
        if (!Product.Name.IsValidMaximumLength(name))
            errors.Add(ProductNameErrors.InvalidMaximumLength);
        
        if(Product.Name.ContainsMultipleSpaces(name))
            errors.Add(ProductNameErrors.MultipleConsecutiveSpaces);
    }

    public async Task<List<Models.Product>> GetAllProducts(string? name, string? category)
    {
        return await _productRepository.GetAllProducts(name, category);
    }



    public async Task<bool> ExistsProductById(int id)
    {
        return await _productRepository.ExistsProductById(id);

    }

    public async Task<Models.Product?> GetProductById(int id)
    {
        return await _productRepository.GetProductById(id);
    }

    public async Task<bool> UpdateProduct(int id, ProductUpdateDto updatedProductDto)
    {
        // Obtener el producto existente del repositorio
        Models.Product? existingProduct = await _productRepository.GetProductById(id);

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

    public async Task<bool> Update(Models.Product product)
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