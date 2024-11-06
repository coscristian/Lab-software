using AutoMapper;
using GestionInventario.Models;
using GestionInventario.Models.Dto;

namespace GestionInventario.AutoMapperProfile;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductDto, Product>();
        CreateMap<Product, ProductDto>();
        CreateMap<MovementDto, Movement>();
    }
}