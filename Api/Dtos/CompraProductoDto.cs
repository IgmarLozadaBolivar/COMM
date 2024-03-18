namespace Api.Dtos;

public class CompraProductoDto
{
    public int Id { get; set; }
    public int IdFacturaCompraFK { get; set; }
    public int IdProductoFK { get; set; }
}