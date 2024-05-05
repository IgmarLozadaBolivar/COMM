using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class VentaProductoConfiguration : IEntityTypeConfiguration<VentaProducto>
{
    public void Configure(EntityTypeBuilder<VentaProducto> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("VentaProducto");

        builder.HasIndex(e => e.IdFacturaVentaFK, "ventaproducto_FacturaVenta_FK");

        builder.HasIndex(e => e.IdProductoFK, "ventaproducto_producto_FK");

        builder.Property(e => e.IdFacturaVentaFK)
            .HasComment("Identificador de puenteo con la tabla de FacturaVenta")
            .HasColumnName("IdFacturaVentaFK");

        builder.Property(e => e.IdProductoFK)
            .HasComment("Identificador de puenteo con la tabla de Producto")
            .HasColumnName("IdProductoFK");

        builder.Property(e => e.FechaVenta)
            .HasComment("Fecha de la venta")
            .HasColumnType("datetime");

        builder.Property(e => e.CantidadVendida)
            .HasComment("Cantidad vendida de un producto");

        builder.HasOne(d => d.FacturaVenta).WithMany(p => p.VentaProductos)
            .HasForeignKey(d => d.IdFacturaVentaFK)
            .HasConstraintName("ventaproducto_facturaventa_FK");

        builder.HasOne(d => d.Producto).WithMany(p => p.VentaProductos)
            .HasForeignKey(d => d.IdProductoFK)
            .HasConstraintName("ventaproducto_producto_FK");
    }
}