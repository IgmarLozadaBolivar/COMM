using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class CompraProductoConfiguration : IEntityTypeConfiguration<CompraProducto>
{
    public void Configure(EntityTypeBuilder<CompraProducto> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("CompraProducto");

        builder.HasIndex(e => e.IdFacturaCompraFK, "compraproducto_FacturaCompra_FK");

        builder.HasIndex(e => e.IdProductoFK, "compraproducto_producto_FK");

        builder.Property(e => e.IdFacturaCompraFK)
            .HasComment("Identificador de puenteo con la tabla de FacturaCompra")
            .HasColumnName("IdFacturaCompraFK");

        builder.Property(e => e.IdProductoFK)
            .HasComment("Identificador de puenteo con la tabla de Producto")
            .HasColumnName("IdProductoFK");

        builder.HasOne(d => d.FacturaCompra).WithMany(p => p.CompraProductos)
            .HasForeignKey(d => d.IdFacturaCompraFK)
            .HasConstraintName("compraproducto_facturacompra_FK");

        builder.HasOne(d => d.Producto).WithMany(p => p.CompraProductos)
            .HasForeignKey(d => d.IdProductoFK)
            .HasConstraintName("compraproducto_producto_FK");
    }
}