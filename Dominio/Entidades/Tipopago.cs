namespace Dominio.Entidades;

public class TipoPago : BaseEntity
{

    public string Descripcion { get; set; }
    public virtual ICollection<FacturaCompra> FacturaCompras { get; set; } = new List<FacturaCompra>();
    public virtual ICollection<FacturaVenta> FacturaVentas { get; set; } = new List<FacturaVenta>();
}