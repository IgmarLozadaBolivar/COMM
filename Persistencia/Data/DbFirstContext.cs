using System.Reflection;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Persistencia.Data;

public partial class DbFirstContext : DbContext
{
    public DbFirstContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<UserRol> UserRols { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Ciudad> Ciudades { get; set; }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<FacturaCompra> FacturaCompras { get; set; }
    public DbSet<FacturaVenta> FacturaVentas { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<TipoPago> TipoPagos { get; set; }
    public DbSet<TipoPersona> TipoPersonas { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
