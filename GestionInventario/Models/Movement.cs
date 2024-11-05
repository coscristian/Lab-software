namespace GestionInventario.Models
{
    public class Movement
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string? Type { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
