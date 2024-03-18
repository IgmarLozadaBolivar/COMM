namespace Dominio.Entidades;

public class VentaProducto : BaseEntity
{
    public int IdFacturaVentaFK { get; set; }
    public FacturaVenta FacturaVenta { get; set; }
    public int IdProductoFK { get; set; }
    public Producto Producto { get; set; }
}