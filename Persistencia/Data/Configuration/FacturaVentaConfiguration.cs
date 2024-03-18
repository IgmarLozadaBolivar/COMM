using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class FacturaVentaConfiguration : IEntityTypeConfiguration<FacturaVenta>
{
    public void Configure(EntityTypeBuilder<FacturaVenta> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("FacturaVenta");

        builder.HasIndex(e => e.IdClienteFk, "facturaventa_persona_FK");

        builder.Property(e => e.Id)
            .HasComment("Identificador de una factura de venta");

        builder.Property(e => e.Cantidad)
            .HasComment("Cantidad de productos");

        builder.Property(e => e.FechaVenta)
            .HasComment("Fecha de la venta")
            .HasColumnType("datetime");

        builder.Property(e => e.IdClienteFk)
            .HasComment("Identificador de puenteo con la tabla de Cliente (Persona)")
            .HasColumnName("IdClienteFk");

        builder.Property(e => e.PrecioTotal)
            .HasPrecision(10, 2)
            .HasComment("Precio total de la venta");
    
        builder.Property(e => e.TipoPago)
            .HasComment("Tipo de pago de los productos en la factura");

        builder.HasOne(d => d.IdClienteFkNavigation).WithMany(p => p.FacturaVentas)
            .HasForeignKey(d => d.IdClienteFk)
            .HasConstraintName("facturaventa_persona_FK");
    }
}