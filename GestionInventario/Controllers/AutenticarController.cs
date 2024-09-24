using GestionInventario.Models;
using GestionInventario.Models.Dto;
using GestionInventario.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GestionInventario.Controllers

{
    public class AutenticarController : Controller
    {
    private IUserServices _userService;

    public AutenticarController(IUserServices userServices) 
        {
            _userService = userServices;
        }

    [HttpPost("ValidarUsuario")]
    public IActionResult ValidarUsuario([FromBody] User usuario)
{
    bool esValido = _userService.ValidarUsuario(usuario); // Ahora pasas el objeto User

    if (esValido)
    {
        UserDto usuarioDto = _userService.GetUserByEmail(usuario.Email);
        return Ok(new
        {
            autenticacionExitosa = true,
            jwt = Guid.NewGuid().ToString(), // Simulación de un token
            mensaje = $"Bienvenido, {usuarioDto.Name} {usuarioDto.LastName}"
        });
    }
    else
    {
        return Unauthorized(new
        {
            autenticacionExitosa = false,
            jwt = (string)null,
            mensaje = "Error al autenticar el usuario"
        });
    }
}


    }

}