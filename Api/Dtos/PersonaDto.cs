namespace Api.Dtos;

public class PersonaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public int Cedula { get; set; }
    public string Correo { get; set; }
    public int Telefono { get; set; }
    public CiudadDto Ciudad { get; set; }
    public TipoPersonaDto TipoPersona { get; set; }
}