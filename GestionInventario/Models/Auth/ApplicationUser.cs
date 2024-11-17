using Microsoft.AspNetCore.Identity;

namespace GestionInventario.Models.Auth;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}