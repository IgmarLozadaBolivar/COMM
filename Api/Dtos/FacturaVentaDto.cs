namespace Api.Dtos;

public class FacturaVentaDto
{
    public int Id { get; set; }
    public DateTime FechaVenta { get; set; }
    public int Cantidad { get; set; }
    public int Iva { get; set; }
    public decimal PrecioTotal { get; set; }
    public PersonaDto Empleado { get; set; }
    public ProductoDto Producto { get; set; }
    public TipoPagoDto TipoPago { get; set; }

}