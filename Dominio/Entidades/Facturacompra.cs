namespace Dominio.Entidades;

public class FacturaCompra : BaseEntity
{
    public DateTime FechaCompra { get; set; }
    public int IdProveedorFk { get; set; }
    public int CantidadTotal { get; set; }
    public decimal PrecioTotal { get; set; }
    public string TipoPago { get; set; }
    public virtual Proveedor IdProveedorFkNavigation { get; set; }
    public virtual ICollection<CompraProducto> CompraProductos { get; set; } = new List<CompraProducto>();
}