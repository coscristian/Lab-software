using GestionInventario.Models;

namespace GestionInventario.Repositories.Interfaces
{
    public interface IMovementRepository
    {
        Task<bool> Add(Movement movement);
    }
}
