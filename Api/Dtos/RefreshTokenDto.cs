namespace Api.Dtos;

public class RefreshTokenDto
{
    public int Id { get; set; }
    public int IdUserFK { get; set; }
    public string Token { get; set; }
    public DateTime TokenExpired { get; set; }
    public DateTime TokenCreated { get; set; }
    public DateTime TokenRevoked { get; set; }
}