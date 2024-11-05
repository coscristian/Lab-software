using AutoMapper;
using GestionInventario.Models;
using GestionInventario.Models.Dto;
using GestionInventario.Repositories.Interfaces;
using GestionInventario.Services.Interfaces;

namespace GestionInventario.Services
{
    public class MovementService : IMovementService
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IMovementRepository _movementRepository;

        public MovementService(IMapper mapper, IProductService productService, IMovementRepository movementRepository)
        {
            _mapper = mapper;
            _productService = productService;
            _movementRepository = movementRepository;
        }

        public async Task<bool> Add(MovementDto movementDto)
        {
            var product = await _productService.GetProductById(movementDto.ProductId);
            if(product is null || movementDto.Amount < 0)
            {
                return false;
            }

            product.Stock = movementDto.Amount;
            var updateStockSuceed = await _productService.Update(product);
            if(!updateStockSuceed)
            {
                return false;
            }


            var mappedMovement = _mapper.Map<MovementDto, Movement>(movementDto);
            mappedMovement.Date = DateTime.Now;

            var result = await _movementRepository.Add(mappedMovement);
            return result;
        }
    }
}
