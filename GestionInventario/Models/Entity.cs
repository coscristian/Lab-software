using GestionInventario.Models.Enums;

namespace GestionInventario.Models;

public class Entity
{
    public int Id { get; set; }
    //public Status Status { get; set; }
    public DateTime CreationDate { get; set; }
    //public User ModificationUser { get; set; }
    public DateTime ModificationDate { get; set; }
    public string MotivoEstado { get; set; }
    // public string ComentarioAuditoria { get; set; }
}