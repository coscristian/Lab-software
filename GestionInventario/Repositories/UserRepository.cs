using GestionInventario.Models;
using GestionInventario.Models.Auth;
using GestionInventario.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GestionInventario.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = [];

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        public List<User> GetAllUsers()
        {
            return _users;
        }

        public async Task AddUser(User user)
        {
            var emailExists = await _userManager.FindByEmailAsync(user.Email);
            if (emailExists is not null)
            {
                return;
            }

            var newUser = new ApplicationUser()
            {
                Email = user.Email,
                UserName = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.Name,
                LastName = user.LastName
            };

            var isCreated = await _userManager.CreateAsync(newUser, "Go2TestPass");
            var roleExists = await _roleManager.RoleExistsAsync("ADMIN");

            // if (!roleExists)
            // {
            //     var roleResult = _userManager.Crea
            //     
            // }
        }

        public User? GetUserByEmail(string email)
        {
            return _users.Find(u => u.Email == email);
        }

        public async Task<User?> GetUserByIdNumberAsync(string idNumber)
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
