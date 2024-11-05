using GestionInventario.Models.Enums;

namespace GestionInventario.Models;

public class Entity
{
    public int Id { get; set; }
    public bool Status { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
    public string MotivoEstado { get; set; }
}