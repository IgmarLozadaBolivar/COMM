namespace Dominio.Entidades;

public class CompraProducto : BaseEntity
{
    public int IdFacturaCompraFK { get; set; }
    public FacturaCompra FacturaCompra { get; set; }
    public int IdProductoFK { get; set; }
    public Producto Producto { get; set; }
}