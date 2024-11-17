using AutoMapper;
using GestionInventario.AutoMapperProfile.Resolvers;
using GestionInventario.Models;
using GestionInventario.Models.Dto;

namespace GestionInventario.AutoMapperProfile;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.CreationDate,
                opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.ModificationDate,
                opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.MotivoEstado,
                opt => opt.MapFrom(src => "Creación"));
        CreateMap<Product, ProductDto>();
        
        CreateMap<MovementDto, Movement>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.CreationDate,
                opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.ModificationDate,
                opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.MotivoEstado,
                opt => opt.MapFrom(src => "Creación"));
        
        CreateMap<SupplierDto, Supplier>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.CreationDate,
                opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.ModificationDate,
                opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.MotivoEstado,
                opt => opt.MapFrom(src => "Creación"));
    }
}