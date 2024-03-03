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

    public virtual DbSet<Categoria> Categorias { get; set; }
    public virtual DbSet<FacturaCompra> FacturaCompras { get; set; }
    public virtual DbSet<FacturaVenta> FacturaVentas { get; set; }
    public virtual DbSet<Persona> Personas { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }
    public virtual DbSet<Proveedor> Proveedores { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<Rol> Rols { get; set; }
    public virtual DbSet<TipoPago> TipoPagos { get; set; }
    public virtual DbSet<TipoPersona> TipoPersonas { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
