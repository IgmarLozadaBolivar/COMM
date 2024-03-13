namespace Dominio.Entidades;

public class FacturaCompra : BaseEntity
{

    public DateTime FechaCompra { get; set; }
    public int IdProveedorFk { get; set; }
    public int IdProductoFk { get; set; }
    public int CantidadxProducto { get; set; }
    public int CantidadTotal { get; set; }
    public decimal PrecioTotal { get; set; }
    public string TipoPago {get; set;}
    public virtual Producto IdProductoFkNavigation { get; set; }
    public virtual Proveedor IdProveedorFkNavigation { get; set; }
}