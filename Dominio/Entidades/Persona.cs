namespace Dominio.Entidades;

public class Persona : BaseEntity
{

    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Cedula { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    
    public virtual ICollection<FacturaVenta> FacturaVentas { get; set; } = new List<FacturaVenta>();
}