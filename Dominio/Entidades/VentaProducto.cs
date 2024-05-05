namespace Dominio.Entidades;

public class VentaProducto : BaseEntity
{
    public int IdFacturaVentaFK { get; set; }
    public FacturaVenta FacturaVenta { get; set; }
    public int IdProductoFK { get; set; }
    public Producto Producto { get; set; }
    public DateTime FechaVenta { get; set; }
    public int CantidadVendida { get; set; }
}