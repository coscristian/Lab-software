using AutoMapper;
using ErrorOr;
using GestionInventario.Common.Responses;
using GestionInventario.Common.Responses.Dto;
using GestionInventario.Models;
using GestionInventario.Models.Dto;
using GestionInventario.Repositories.Interfaces;
using GestionInventario.Services.Interfaces;

namespace GestionInventario.Services
{
    public class UserService : IUserServices
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Response<UserResponseDto>>> CreateUser(UserDto userDto)
        {
            try
            {
                var existingUser = await _userRepository.GetUserByIdNumberAsync(userDto.IdNumber);
                /*if (existingUser is not null)
                {
                    return Error(); // TODO: This User Already Exists.
                }*/
                
                // TODO: Validate fields (Name, IdNumber, Address...)
                var mappedUser = _mapper.Map<UserDto, User>(userDto);
                
                
                
                //var existingUser = users.Find(u => u.IdNumber == newUser.IdNumber);
                return _userRepository.Add(newUser);
            }
            catch(Exception ex)
            {
                // TODO: Implement Exception
                return false;
            }
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
                    PhoneNumber = user.PhoneNumber,
                    Status = user.Status
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


