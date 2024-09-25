using GestionInventario.Models;
using GestionInventario.Models.Dto;
using GestionInventario.Repositories.Interfaces;
using GestionInventario.Services.Interfaces;

namespace GestionInventario.Services
{
    public class UserService : IUserServices
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CreateUser(User newUser)
        {
            var users = _userRepository.GetAllUsers();
            var existingUser = users.Find(u => u.IdNumber == newUser.IdNumber);
            
            if (existingUser != null)
                return false;

            return _userRepository.Add(newUser);
        }

        public List<UserDto> GeAlltUsers()
        {
            var users = _userRepository.GetAllUsers();
            if(users == null || users.Count == 0) return new List<UserDto>();

            var usersDto = new List<UserDto>();
            foreach (var user in users)
            {
                usersDto.Add(new UserDto()
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber
                });
            }

            return usersDto;
        }

        public UserDto GetUserByEmail(string email)
        {
            User? user = _userRepository.GetUserByEmail(email);
            if (user == null)
                return new UserDto();

            return new UserDto()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status
            };
        }

        public bool UpdateUser( string idNumber, bool status)
        {
            User? user = _userRepository.GetUserByIdNumber(idNumber);
            if (user == null)
                return false;

            return _userRepository.UpdateUserStatus(idNumber, status);
        }
        
        public bool ValidarUsuario(string email, string password)
        {
            User? existingUser = _userRepository.GetUserByEmail(email);
    
            return existingUser != null && existingUser.Password == password;
        }
     }
}


