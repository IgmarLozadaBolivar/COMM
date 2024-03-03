using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("Rol");

        builder.Property(e => e.Id).HasComment("Identificador de rol");
        builder.Property(e => e.Nombre)
            .HasMaxLength(25)
            .HasComment("Nombre del rol");
    }
}