namespace Dominio.Entidades;

public class FacturaVenta : BaseEntity
{
    public DateTime FechaVenta { get; set; }
    public int IdClienteFk { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioTotal { get; set; }
    public string TipoPago { get; set; }
    public virtual Persona IdClienteFkNavigation { get; set; }
    public virtual ICollection<VentaProducto> VentaProductos { get; set; } = new List<VentaProducto>();
}