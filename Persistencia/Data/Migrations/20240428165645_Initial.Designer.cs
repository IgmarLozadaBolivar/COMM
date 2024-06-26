﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia.Data;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(DbFirstContext))]
    [Migration("20240428165645_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Dominio.Entidades.CompraProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdFacturaCompraFK")
                        .HasColumnType("int")
                        .HasColumnName("IdFacturaCompraFK")
                        .HasComment("Identificador de puenteo con la tabla de FacturaCompra");

                    b.Property<int>("IdProductoFK")
                        .HasColumnType("int")
                        .HasColumnName("IdProductoFK")
                        .HasComment("Identificador de puenteo con la tabla de Producto");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdFacturaCompraFK" }, "compraproducto_FacturaCompra_FK");

                    b.HasIndex(new[] { "IdProductoFK" }, "compraproducto_producto_FK");

                    b.ToTable("CompraProducto", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.FacturaCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador de la factura de compra");

                    b.Property<int>("CantidadTotal")
                        .HasColumnType("int")
                        .HasComment("Cantidad total de todos los productos");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de la compra");

                    b.Property<int>("IdProveedorFk")
                        .HasColumnType("int")
                        .HasColumnName("IdProveedorFK")
                        .HasComment("Identificador de puenteo con la tabla de Proveedor");

                    b.Property<decimal>("PrecioTotal")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasComment("Precio total de los productos en la factura");

                    b.Property<string>("TipoPago")
                        .HasColumnType("varchar(25)")
                        .HasComment("Tipo de pago de los productos en la factura");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdProveedorFk" }, "facturacompra_proveedor_FK");

                    b.ToTable("FacturaCompra", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.FacturaVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador de una factura de venta");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasComment("Cantidad de productos");

                    b.Property<DateTime>("FechaVenta")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de la venta");

                    b.Property<int>("IdClienteFk")
                        .HasColumnType("int")
                        .HasColumnName("IdClienteFk")
                        .HasComment("Identificador de puenteo con la tabla de Cliente (Persona)");

                    b.Property<string>("TipoCliente")
                        .HasColumnType("varchar(25)")
                        .HasComment("Tipo de cliente en la factura");

                    b.Property<string>("Observacion")
                        .HasColumnType("varchar(225)")
                        .HasComment("Observacion del cliente en la factura");

                    b.Property<decimal>("PrecioTotal")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasComment("Precio total de la venta");

                    b.Property<string>("TipoPago")
                        .HasColumnType("varchar(25)")
                        .HasComment("Tipo de pago de los productos en la factura");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdClienteFk" }, "facturaventa_persona_FK");

                    b.ToTable("FacturaVenta", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador de la persona");

                    b.Property<string>("Apellidos")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasComment("Apellidos de la persona");

                    b.Property<string>("Cedula")
                        .HasColumnType("varchar(255)")
                        .HasComment("Número de identificación");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("Correo electrónico de la persona");

                    b.Property<string>("Nombre")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasComment("Nombre de la persona");

                    b.Property<string>("Telefono")
                        .HasColumnType("varchar(255)")
                        .HasComment("Teléfono de la persona");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Cedula", "Correo", "Telefono" }, "persona_unique")
                        .IsUnique();

                    b.ToTable("Persona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodigoBarras")
                        .HasColumnType("longtext")
                        .HasComment("Código de barras del producto");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Descripción del producto");

                    b.Property<string>("Nombre")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasComment("Nombre del producto");

                    b.Property<decimal>("PrecioCompra")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasComment("Precio de compra del producto");

                    b.Property<decimal>("PrecioVenta")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasComment("Precio de venta del producto");

                    b.Property<string>("Presentacion")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasComment("Presentación del producto, si es que incluye sea desde tallas, tamaños, unidades entre otros");

                    b.Property<int>("TotalExistencias")
                        .HasColumnType("int")
                        .HasComment("Cantidad o existencia total por producto");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Proveedor", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdUserFK")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("TokenExpired")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("TokenRevoked")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("IdUserFK");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Dominio.Entidades.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador de rol");

                    b.Property<string>("Nombre")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasComment("Nombre del rol");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identificador de usuario");

                    b.Property<string>("Nombre")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasComment("Nombre del usuario");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasComment("Contraseña del usuario");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.UserRol", b =>
                {
                    b.Property<int>("IdUserFK")
                        .HasColumnType("int");

                    b.Property<int>("IdRolFK")
                        .HasColumnType("int");

                    b.HasKey("IdUserFK", "IdRolFK");

                    b.HasIndex("IdRolFK");

                    b.ToTable("user_rol", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.VentaProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdFacturaVentaFK")
                        .HasColumnType("int")
                        .HasColumnName("IdFacturaVentaFK")
                        .HasComment("Identificador de puenteo con la tabla de FacturaVenta");

                    b.Property<int>("IdProductoFK")
                        .HasColumnType("int")
                        .HasColumnName("IdProductoFK")
                        .HasComment("Identificador de puenteo con la tabla de Producto");

                    b.Property<DateTime>("FechaVenta")
                        .HasColumnType("datetime")
                        .HasComment("Fecha de la venta");

                    b.Property<int>("CantidadVendida")
                        .HasColumnType("int")
                        .HasColumnName("CantidadVendida")
                        .HasComment("Cantidad vendida de un producto");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdFacturaVentaFK" }, "ventaproducto_FacturaVenta_FK");

                    b.HasIndex(new[] { "IdProductoFK" }, "ventaproducto_producto_FK");

                    b.ToTable("VentaProducto", (string)null);
                });

            modelBuilder.Entity("Dominio.Entidades.CompraProducto", b =>
                {
                    b.HasOne("Dominio.Entidades.FacturaCompra", "FacturaCompra")
                        .WithMany("CompraProductos")
                        .HasForeignKey("IdFacturaCompraFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("compraproducto_facturacompra_FK");

                    b.HasOne("Dominio.Entidades.Producto", "Producto")
                        .WithMany("CompraProductos")
                        .HasForeignKey("IdProductoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("compraproducto_producto_FK");

                    b.Navigation("FacturaCompra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Dominio.Entidades.FacturaCompra", b =>
                {
                    b.HasOne("Dominio.Entidades.Proveedor", "IdProveedorFkNavigation")
                        .WithMany("FacturaCompras")
                        .HasForeignKey("IdProveedorFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("facturacompra_proveedor_FK");

                    b.Navigation("IdProveedorFkNavigation");
                });

            modelBuilder.Entity("Dominio.Entidades.FacturaVenta", b =>
                {
                    b.HasOne("Dominio.Entidades.Persona", "IdClienteFkNavigation")
                        .WithMany("FacturaVentas")
                        .HasForeignKey("IdClienteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("facturaventa_persona_FK");

                    b.Navigation("IdClienteFkNavigation");
                });

            modelBuilder.Entity("Dominio.Entidades.RefreshToken", b =>
                {
                    b.HasOne("Dominio.Entidades.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("IdUserFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dominio.Entidades.UserRol", b =>
                {
                    b.HasOne("Dominio.Entidades.Rol", "Rol")
                        .WithMany("UserRols")
                        .HasForeignKey("IdRolFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.User", "User")
                        .WithMany("UserRols")
                        .HasForeignKey("IdUserFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dominio.Entidades.VentaProducto", b =>
                {
                    b.HasOne("Dominio.Entidades.FacturaVenta", "FacturaVenta")
                        .WithMany("VentaProductos")
                        .HasForeignKey("IdFacturaVentaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ventaproducto_facturaventa_FK");

                    b.HasOne("Dominio.Entidades.Producto", "Producto")
                        .WithMany("VentaProductos")
                        .HasForeignKey("IdProductoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ventaproducto_producto_FK");

                    b.Navigation("FacturaVenta");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Dominio.Entidades.FacturaCompra", b =>
                {
                    b.Navigation("CompraProductos");
                });

            modelBuilder.Entity("Dominio.Entidades.FacturaVenta", b =>
                {
                    b.Navigation("VentaProductos");
                });

            modelBuilder.Entity("Dominio.Entidades.Persona", b =>
                {
                    b.Navigation("FacturaVentas");
                });

            modelBuilder.Entity("Dominio.Entidades.Producto", b =>
                {
                    b.Navigation("CompraProductos");

                    b.Navigation("VentaProductos");
                });

            modelBuilder.Entity("Dominio.Entidades.Proveedor", b =>
                {
                    b.Navigation("FacturaCompras");
                });

            modelBuilder.Entity("Dominio.Entidades.Rol", b =>
                {
                    b.Navigation("UserRols");
                });

            modelBuilder.Entity("Dominio.Entidades.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserRols");
                });
#pragma warning restore 612, 618
        }
    }
}
