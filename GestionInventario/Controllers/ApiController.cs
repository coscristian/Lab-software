using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventario.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        HttpContext.Items["errors"] = errors;
        var firstError = errors[0];
        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        //Dictionary<string, string> errorsDict = errors.ToDictionary(e => e.Code, e => e.Description); 
        
        return Problem(statusCode: statusCode, title: firstError.Description); // TODO: Poner mensaje de error de validación
        //return Problem(statusCode: statusCode, title: firstError.Description);
    }
}