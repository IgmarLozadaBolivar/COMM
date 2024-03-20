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

        builder.Property(e => e.CodigoBarras)
            .HasComment("Código de barras del producto");

        builder.Property(e => e.Descripcion)
            .HasMaxLength(100)
            .HasComment("Descripción del producto");

        builder.Property(e => e.Categoria)
            .HasPrecision(10, 2)
            .HasComment("Categoría de los productos en la factura");

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
            .HasComment("Presentación del producto, si es que incluye sea desde tallas, tamaños, unidades entre otros");

        builder.Property(e => e.TotalExistencias)
            .HasComment("Cantidad o existencia total por producto");

        
    }
}