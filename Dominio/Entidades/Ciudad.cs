namespace Dominio.Entidades;

public class Ciudad : BaseEntity
{
    public string Nombre { get; set; }
    public int IdDepartamentoFK { get; set; }
    public Departamento Departamento { get; set; }
    public ICollection<Persona> Personas { get; set; } = new List<Persona>();
}