using Dominio.Entidades;

namespace Api.Dtos;

public class VentaProductoDto
{
    public int Id { get; set; }
    public int IdFacturaVentaFK { get; set; }
    public int IdProductoFK { get; set; }
}