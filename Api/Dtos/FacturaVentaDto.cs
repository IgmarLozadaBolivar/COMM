namespace Api.Dtos;

public class FacturaVentaDto
{
    public int Id { get; set; }
    public DateTime FechaVenta { get; set; }
    public int Cantidad { get; set; }
    public int Iva { get; set; }
    public decimal PrecioTotal { get; set; }
    public int IdEmpleadoFk { get; set; }
    public int IdProductoFk { get; set; }
}