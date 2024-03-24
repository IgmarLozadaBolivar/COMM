namespace Api.Dtos;

public class ProductoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; } = 0.00m;
    public string UsoClinico { get; set; }
    public string CodigoBarras { get; set; }
    public string Descripcion { get; set; }
    public string Presentacion { get; set; }
    public int TotalExistencias { get; set; }

}