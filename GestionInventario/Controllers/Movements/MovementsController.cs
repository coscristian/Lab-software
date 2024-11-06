using AutoMapper;
using GestionInventario.Models.Dto;
using GestionInventario.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

namespace GestionInventario.Controllers.Movements;

[ApiController]
[Route("api/[controller]")]
public class MovementsController : ControllerBase
{
    private readonly IMovementService _movementService;

    public MovementsController(IMovementService movementService)
    {
        _movementService = movementService;
    }

    [HttpPut]
    [Route("UpdateInv")]
    public async Task<IActionResult> Add([FromBody] MovementDto movementDto)
    {
        var result = await _movementService.Add(movementDto);
        return Ok(result);
    }
}