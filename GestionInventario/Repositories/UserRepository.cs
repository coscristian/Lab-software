using GestionInventario.Models;
using GestionInventario.Repositories.Interfaces;

namespace GestionInventario.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = [];

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public bool Add(User user)
        {
            _users.Add(user);
            return true;
        }

        public User? GetUserByEmail(string email)
        {
            return _users.Find(u => u.Email == email);
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public User? GetUserByIdNumber(string idNumber)
        {
            return _users.Find(u => u.IdNumber == idNumber);
        }

        public bool UpdateUserStatus(string idNumber, bool status)
        {
            var user = _users.Find(u => u.IdNumber.Equals(idNumber));
            user.Status = status;
            return true;
        }
    }
}
