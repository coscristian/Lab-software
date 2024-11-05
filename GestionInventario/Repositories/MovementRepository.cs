using GestionInventario.Models;
using GestionInventario.Repositories.Interfaces;

namespace GestionInventario.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly MyDbContext _context;

        public MovementRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Movement movement)
        {
            await _context.Movements.AddAsync(movement);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
