using GestionInventario.Models;
using GestionInventario.Models.Dto;
using GestionInventario.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventario.Controllers

{
    [ApiController] // TODO: Eliminar este atributo
    [Route("api/[controller]")]
    public class AutenticarController : ControllerBase
    {
        private readonly IUserServices _userService;

        public AutenticarController(IUserServices userServices)
        {
            _userService = userServices;
        }

        [HttpPost("ValidateUser")]
        public IActionResult ValidarUsuario(UserValidationRequest user)
        {
            bool esValido = _userService.ValidarUsuario(user.Email, user.Password);

            if (esValido)
            {
                UserDto usuarioDto = _userService.GetUserByEmail(user.Email);
                return Ok(new
                {
                    autenticacionExitosa = true,
                    jwt = Guid.NewGuid().ToString(),
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