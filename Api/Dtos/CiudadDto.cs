namespace Api.Dtos;

public class CiudadDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public DepartamentoDto Departamento { get; set; }

}