namespace Dominio.Entidades;

public class Proveedor : BaseEntity
{

    public string Nombre { get; set; }
    public virtual ICollection<FacturaCompra> FacturaCompras { get; set; } = new List<FacturaCompra>();
}