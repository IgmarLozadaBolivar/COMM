using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.HasKey(d => d.Id);

        builder.ToTable("Ciudad");

        builder.Property(e => e.Id).HasColumnName("Id");
        builder.Property(e => e.Nombre)
            .HasMaxLength(25)
            .HasColumnName("Nombre");

        builder.HasOne(p => p.Departamento)
            .WithMany(p => p.Ciudades)
            .HasForeignKey(p => p.IdDepartamentoFK);
    }
}