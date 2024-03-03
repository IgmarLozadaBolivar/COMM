using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
{
    public void Configure(EntityTypeBuilder<TipoPersona> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("TipoPersona");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasComment("Identificador de tipo de persona");
        builder.Property(e => e.Nombre)
            .HasMaxLength(25)
            .HasComment("Nombre del tipo de persona");
    }
}