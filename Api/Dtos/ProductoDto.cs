namespace Api.Dtos;

public class ProductoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string UsoClinico { get; set; }
    public int CodigoBarras { get; set; }
    public string Marca { get; set; }
    public string Descripcion { get; set; }
    public string Presentacion { get; set; }
    public int TotalExistencias { get; set; }
    public CategoriaDto Categoria { get; set; }

}