using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("Persona");

        builder.HasIndex(e => new { e.Cedula, e.Correo, e.Telefono }, "persona_unique").IsUnique();

        builder.Property(e => e.Id).HasComment("Identificador de la persona");
        builder.Property(e => e.Apellidos)
            .HasMaxLength(25)
            .HasComment("Apellidos de la persona");
        builder.Property(e => e.Cedula).HasComment("Numero de identificacion");
        builder.Property(e => e.Correo)
            .HasMaxLength(50)
            .HasComment("Correo electronico de la persona");
        builder.Property(e => e.Nombre)
            .HasMaxLength(25)
            .HasComment("Nombre de la persona");
        builder.Property(e => e.Telefono).HasComment("Telefono de la persona");
    }
}