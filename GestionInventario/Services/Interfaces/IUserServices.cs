using GestionInventario.Common.Responses;
using GestionInventario.Common.Responses.Dto;
using GestionInventario.Models;
using GestionInventario.Models.Dto;
using ErrorOr;

namespace GestionInventario.Services.Interfaces
{
    public interface IUserServices
    {
        Task<ErrorOr<Response<UserResponseDto>>> CreateUser(UserDto newUser);
        UserDto GetUserByEmail(string email);
        List<UserDto> GeAlltUsers();
        bool UpdateUser(string idNumber, bool status);
        bool ValidarUsuario(string email, string password);
    }
}
