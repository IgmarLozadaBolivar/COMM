namespace Api.Dtos;

public class FacturaCompraDto
{
    public int Id { get; set; }
    public DateTime FechaCompra { get; set; }
    public int CantidadTotal { get; set; }
    public decimal PrecioTotal { get; set; }
    public int IdProveedorFk { get; set; }
    public string TipoPago { get; set; }
}