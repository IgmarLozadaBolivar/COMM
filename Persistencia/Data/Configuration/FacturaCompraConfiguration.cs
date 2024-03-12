using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class FacturaCompraConfiguration : IEntityTypeConfiguration<FacturaCompra>
{
    public void Configure(EntityTypeBuilder<FacturaCompra> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("FacturaCompra");

        builder.HasIndex(e => e.IdEmpleadoFk, "facturacompra_persona_FK");

        builder.HasIndex(e => e.IdProductoFk, "facturacompra_producto_FK");

        builder.HasIndex(e => e.IdProveedorFk, "facturacompra_proveedor_FK");

        builder.HasIndex(e => e.IdTipoPagoFk, "facturacompra_tipopago_FK");

        builder.Property(e => e.Id).HasComment("Identificador de la factura de compra");
        builder.Property(e => e.CantidadTotal).HasComment("Cantidad total de todos los productos");
        builder.Property(e => e.CantidadxProducto).HasComment("Cantidad por productos");
        builder.Property(e => e.FechaCompra)
            .HasComment("Fecha de la compra")
            .HasColumnType("datetime");
        builder.Property(e => e.IdEmpleadoFk)
            .HasComment("Identificador puenteo con la tabla de Empleado (Persona)")
            .HasColumnName("IdEmpleadoFK");
        builder.Property(e => e.IdProductoFk)
            .HasComment("Identificador de puenteo con la tabla de Producto")
            .HasColumnName("IdProductoFK");
        builder.Property(e => e.IdProveedorFk)
            .HasComment("Identificador de puenteo con la tabla de Proveedor")
            .HasColumnName("IdProveedorFK");
        builder.Property(e => e.IdTipoPagoFk)
            .HasComment("Identificador de puenteo con la tabla de Tipo Pago")
            .HasColumnName("IdTipoPagoFK");
        builder.Property(e => e.PrecioTotal)
            .HasPrecision(10, 2)
            .HasComment("Precio total de los productos en la factura");

        builder.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.FacturaCompras)
            .HasForeignKey(d => d.IdEmpleadoFk)
            .HasConstraintName("facturacompra_persona_FK");

        builder.HasOne(d => d.IdProductoFkNavigation).WithMany(p => p.FacturaCompras)
            .HasForeignKey(d => d.IdProductoFk)
            .HasConstraintName("facturacompra_producto_FK");

        builder.HasOne(d => d.IdProveedorFkNavigation).WithMany(p => p.FacturaCompras)
            .HasForeignKey(d => d.IdProveedorFk)
            .HasConstraintName("facturacompra_proveedor_FK");
    }
}