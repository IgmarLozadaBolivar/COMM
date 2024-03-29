namespace Api.Dtos;

public class FacturaCompraDto
{
    public int Id { get; set; }
    public DateTime FechaCompra { get; set; }
    public int CantidadxProducto { get; set; }
    public int CantidadTotal { get; set; }
    public decimal PrecioTotal { get; set; }
    public ProveedorDto Proveedor { get; set; }
    public ProductoDto Producto { get; set; }
    public TipoPagoDto TipoPago { get; set; }
    public PersonaDto Empleado { get; set; }

}