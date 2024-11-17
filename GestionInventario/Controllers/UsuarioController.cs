using GestionInventario.Models;
using GestionInventario.Models.Dto;
using GestionInventario.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventario.Controllers
{
    [ApiController] // TODO: Eliminar este atributo
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UsuarioController(IUserServices userServices)
        {
            _userService = userServices;
        }

        [HttpGet]
        [Route("GetUserByEmail")]
        public ActionResult<UserDto> GetUserByEmail(string email)
        {
            try
            {
                UserDto userDto = _userService.GetUserByEmail(email);
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return BadRequest(ex.Message);
                return StatusCode(500,
                    new
                    {
                        mensaje = "Ocurrio un error interno en el servidor",
                        detalles = ex.Message
                    }
                );
            }

        }

        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult<List<UserDto>> GetAllUsers()
        {
            List<UserDto> usersDto = _userService.GeAlltUsers();
            return Ok(usersDto);
        }
/*
        [HttpPost]
        [Route("CreateUser")]
        public ActionResult<UserDto> CreateUser(UserDto userDto)
        {
            try
            {
                if(userDto == null){
                    return  BadRequest("El cliente no puede ser nulo");
                }
                _userService.CreateUser(user);
                return CreatedAtAction(nameof(GetAllUsers), new {id = user.Id}, user);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return BadRequest(ex.Message);
                return StatusCode(500,
                    new
                    {
                        mensaje = "Ocurrio un error interno en el servidor",
                        detalles = ex.Message
                    }
                );
            }
            var result = _userService.CreateUser(userDto);

        }*/

        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult<bool> UpdateUser(string idNumber, bool status)
        {
            var result = _userService.UpdateUser(idNumber, status);
            return Ok(result);
        }
    }
}
