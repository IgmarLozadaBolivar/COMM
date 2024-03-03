using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class TipoPagoConfiguration : IEntityTypeConfiguration<TipoPago>
{
    public void Configure(EntityTypeBuilder<TipoPago> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("TipoPago");

        builder.Property(e => e.Id).HasComment("Identificador de tipo de pago");
        builder.Property(e => e.Descripcion)
            .HasMaxLength(50)
            .HasComment("Descripcion del tipo de pago");
    }
}