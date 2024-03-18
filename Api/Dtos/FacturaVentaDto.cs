namespace Api.Dtos;

public class FacturaVentaDto
{
    public int Id { get; set; }
    public DateTime FechaVenta { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioTotal { get; set; }
    public int IdClienteFk { get; set; }
    public string TipoPago { get; set; }
}