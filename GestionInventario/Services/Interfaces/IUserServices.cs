using GestionInventario.Models;
using GestionInventario.Models.Dto;

namespace GestionInventario.Services.Interfaces
{
    public interface IUserServices
    {
        UserDto GetUserByEmail(string email);
        List<UserDto> GeAlltUsers();
        bool CreateUser(User newUser);
        bool UpdateUser(string idNumber, bool status);

        bool ValidarUsuario(User usuario);
    }
}
