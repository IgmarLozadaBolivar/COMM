namespace Dominio.Entidades;

public class Categoria : BaseEntity
{

    public string Descripcion { get; set; }
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}