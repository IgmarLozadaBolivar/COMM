namespace Dominio.Entidades;

public class Departamento : BaseEntity
{

    public string Nombre { get; set; }
    public virtual ICollection<Ciudad> Ciudades { get; set; } = new List<Ciudad>();
}