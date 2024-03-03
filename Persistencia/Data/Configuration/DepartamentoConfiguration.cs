using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.HasKey(d => d.Id);

        builder.ToTable("Departamento");

        builder.Property(e => e.Id).HasColumnName("Id");
        builder.Property(e => e.Nombre)
            .HasMaxLength(25)
            .HasColumnName("Nombre");
    }
}