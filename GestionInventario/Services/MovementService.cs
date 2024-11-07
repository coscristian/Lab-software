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
                // TODO: Retornar mensaje de respuesta que indique que el producto no existe o la cantidad es invalida
                return false;
            }

            var mostRecentMovement = await _movementRepository.GetMostRecentMovementById(product.Id);
            if (mostRecentMovement is null)
            {
                if (movementDto.Type != "Adicionar")
                    return false;

                mostRecentMovement = new Movement { TotalAmount = 0 };
            }

            var totalMovement = 0;
            switch (movementDto.Type)
            {
                case "Adicionar":
                    totalMovement = movementDto.Amount + mostRecentMovement.TotalAmount;
                    break;
                case "Disminuir":
                    // TODO: Retornar mensaje de respuesta: La cantidad a disminuir no debe ser mayor a la actual
                    if (movementDto.Amount > mostRecentMovement!.TotalAmount)
                        return false;

                    totalMovement = mostRecentMovement.TotalAmount - movementDto.Amount;
                    break;
                default:
                    // TODO: Retornar mensaje de respuesta que indique que debe indicar un movimiento correcto
                    return false;
                    break;
            }
            var mappedMovement = _mapper.Map<MovementDto, Movement>(movementDto);
            mappedMovement.Date = DateTime.Now;
            mappedMovement.TotalAmount = totalMovement;

            var result = await _movementRepository.Add(mappedMovement);
            return result;
        }
    }
}
