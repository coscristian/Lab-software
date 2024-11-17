using GestionInventario.Models;

namespace GestionInventario.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User? GetUserByEmail(string email);
        public Task<User?> GetUserByIdNumberAsync(string idNumber);
        public List<User> GetAllUsers();
        public bool UpdateUserStatus(string idNumber, bool status);
        public Task AddUser(User user);

    }
}
