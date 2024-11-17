namespace GestionInventario.Models
{
    public class Movement : Entity
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }
        public int TotalAmount { get; set; }
        public decimal Value { get; set; }
        public string? Type { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
    }
}
