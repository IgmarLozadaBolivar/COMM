using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("Producto");

        builder.HasIndex(e => e.IdCategoriaFk, "producto_categoria_FK");

        builder.Property(e => e.CodigoBarras).HasComment("Codigo de barras del producto");
        builder.Property(e => e.Descripcion)
            .HasMaxLength(100)
            .HasComment("Descripcion del producto");
        builder.Property(e => e.IdCategoriaFk)
            .HasComment("Identificador de puenteo con la tabla Categoria")
            .HasColumnName("IdCategoriaFK");
        builder.Property(e => e.Marca)
            .HasMaxLength(25)
            .HasComment("Nombre de la marca del producto");
        builder.Property(e => e.Nombre)
            .HasMaxLength(25)
            .HasComment("Nombre del producto");
        builder.Property(e => e.Precio)
            .HasPrecision(10, 2)
            .HasComment("Precio de venta del producto");
        builder.Property(e => e.Presentacion)
            .HasMaxLength(25)
            .HasComment("Presentacion del producto, si es que incluye sea desde tallas, tamaños, unidades entre otros.");
        builder.Property(e => e.TotalExistencias).HasComment("Cantidad o existencia total por producto");
        builder.Property(e => e.UsoClinico).HasColumnType("enum('SI','NO')");

        builder.HasOne(d => d.IdCategoriaFkNavigation).WithMany(p => p.Productos)
            .HasForeignKey(d => d.IdCategoriaFk)
            .HasConstraintName("producto_categoria_FK");
    }
}