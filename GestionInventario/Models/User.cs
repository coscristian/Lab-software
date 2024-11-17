namespace GestionInventario.Models
{
    public class User : Entity
    {
        // TODO: Max Length to string var
        public string IdNumber { get; set; } = string.Empty;
        public string IdType { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Status { get; set; }
        
        // public List<Role> Role { get; set; } TODO: Add role to User
    }
}
