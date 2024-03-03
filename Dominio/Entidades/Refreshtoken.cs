namespace Dominio.Entidades;

public class RefreshToken : BaseEntity
{
    public int IdUserFK { get; set; }
    public User User { get; set; }
    public string Token { get; set; }
    public DateTime TokenExpired { get; set; }
    public bool TokenIsExpired => DateTime.UtcNow >= TokenExpired;
    public DateTime TokenCreated { get; set; }
    public DateTime? TokenRevoked { get; set; }
    public bool IsActive => TokenRevoked == null && !TokenIsExpired;
}