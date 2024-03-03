namespace Dominio.Entidades;

public class FacturaVenta : BaseEntity
{

    public DateTime FechaVenta { get; set; }
    public int IdEmpleadoFk { get; set; }
    public int IdProductoFk { get; set; }
    public int Cantidad { get; set; }
    public int Iva { get; set; }
    public decimal PrecioTotal { get; set; }
    public int IdTipoPagoFk { get; set; }
    public virtual Persona IdEmpleadoFkNavigation { get; set; }
    public virtual Producto IdProductoFkNavigation { get; set; }
    public virtual TipoPago IdTipoPagoFkNavigation { get; set; }
}