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

        builder.HasIndex(e => e.IdEmpleadoFk, "facturaventa_persona_FK");

        builder.HasIndex(e => e.IdProductoFk, "facturaventa_producto_FK");

        builder.Property(e => e.Id)
            .HasComment("Identificador de una factura de venta");

        builder.Property(e => e.Cantidad)
            .HasComment("Cantidad de productos");

        builder.Property(e => e.FechaVenta)
            .HasComment("Fecha de la venta")
            .HasColumnType("datetime");

        builder.Property(e => e.IdEmpleadoFk)
            .HasComment("Identificador de puenteo con la tabla de Empleado (Persona)")
            .HasColumnName("IdEmpleadoFK");   

        builder.Property(e => e.IdProductoFk)
            .HasComment("Identificador de puenteo con la tabla de Producto")
            .HasColumnName("IdProductoFK"); 

        builder.Property(e => e.Iva)
            .HasComment("IVA o comisión por compra, establecido por el gobierno");

        builder.Property(e => e.PrecioTotal)
            .HasPrecision(10, 2)
            .HasComment("Precio total de la venta");
    
        builder.Property(e => e.TipoPago)
            .HasComment("Tipo de pago de los productos en la factura");

        builder.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.FacturaVentas)
            .HasForeignKey(d => d.IdEmpleadoFk)
            .HasConstraintName("facturaventa_persona_FK");

        builder.HasOne(d => d.IdProductoFkNavigation).WithMany(p => p.FacturaVentas)
            .HasForeignKey(d => d.IdProductoFk)
            .HasConstraintName("facturaventa_producto_FK");
    }
}