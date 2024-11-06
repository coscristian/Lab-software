using GestionInventario.Models.Dto;

namespace GestionInventario.Services.Interfaces
{
    public interface IMovementService
    {
        Task<bool> Add(MovementDto movementDto);
    }
}
