namespace Dominio.Entidades;

public class TipoPersona : BaseEntity
{

    public string Nombre { get; set; }
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}