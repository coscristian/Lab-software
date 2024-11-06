namespace GestionInventario.Models.Dto
{
    public class MovementDto
    {
        public int Amount { get; set; }
        public string? Type { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
    }
}
