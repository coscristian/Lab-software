namespace GestionInventario.Models.Dto
{
    public class UserValidationRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
