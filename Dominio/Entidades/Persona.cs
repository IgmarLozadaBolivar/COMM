namespace Dominio.Entidades;

public class Persona : BaseEntity
{

    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public int Cedula { get; set; }
    public string Correo { get; set; }
    public int Telefono { get; set; }
    public int IdCiudadFK { get; set; }
    public Ciudad Ciudad { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public virtual ICollection<FacturaCompra> FacturaCompras { get; set; } = new List<FacturaCompra>();
    public virtual ICollection<FacturaVenta> FacturaVentas { get; set; } = new List<FacturaVenta>();
    public virtual TipoPersona IdTipoPersonaFkNavigation { get; set; }
}