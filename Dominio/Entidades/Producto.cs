namespace Dominio.Entidades;

public class Producto : BaseEntity
{
 
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string UsoClinico { get; set; }
    public int CodigoBarras { get; set; }
    public string Marca { get; set; }
    public string Descripcion { get; set; }
    public string Presentacion { get; set; }
    public int IdCategoriaFk { get; set; }
    public int TotalExistencias { get; set; }
    public virtual ICollection<FacturaCompra> FacturaCompras { get; set; } = new List<FacturaCompra>();
    public virtual ICollection<FacturaVenta> FacturaVentas { get; set; } = new List<FacturaVenta>();
    public virtual Categoria IdCategoriaFkNavigation { get; set; }
}