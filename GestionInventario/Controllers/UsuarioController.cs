using GestionInventario.Models;
using GestionInventario.Models.Dto;
using GestionInventario.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventario.Controllers
{
    [ApiController]
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
            UserDto userDto = _userService.GetUserByEmail(email);  
            return Ok(userDto);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult<List<UserDto>> GetAllUsers()
        {
            List<UserDto> usersDto = _userService.GeAlltUsers();
            return Ok(usersDto);
        }

        [HttpPost]
        [Route("CreateUser")]
        public ActionResult<List<UserDto>> CreateUser(User user)
        {
            var result = _userService.CreateUser(user);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult<bool> UpdateUser(string idNumber, bool status)
        {
            var result = _userService.UpdateUser(idNumber, status);
            return Ok(result);
        }
    }
}
