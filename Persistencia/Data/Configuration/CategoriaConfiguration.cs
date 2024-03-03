using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("Categoria");

        builder.Property(e => e.Id).HasComment("Identificador de categoria");
        builder.Property(e => e.Descripcion)
            .HasMaxLength(150)
            .HasComment("Descripción de la categoria");
    }
}