namespace GestionInventario.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string IdType { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        
        // public List<Role> Role { get; set; }
        
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
