using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador de la persona")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true, comment: "Nombre de la persona", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellidos = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true, comment: "Apellidos de la persona", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cedula = table.Column<string>(type: "varchar(255)", nullable: true, comment: "Número de identificación", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "Correo electrónico de la persona", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(255)", nullable: true, comment: "Teléfono de la persona", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador de rol")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true, comment: "Nombre del rol", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador de usuario")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true, comment: "Nombre del usuario", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "Contraseña del usuario", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "FacturaCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador de la factura de compra")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCompra = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la compra"),
                    IdProveedorFK = table.Column<int>(type: "int", nullable: false, comment: "Identificador de puenteo con la tabla de Proveedor"),
                    CantidadTotal = table.Column<int>(type: "int", nullable: false, comment: "Cantidad total de todos los productos"),
                    PrecioTotal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Precio total de los productos en la factura"),
                    TipoPago = table.Column<string>(type: "varchar(25)", nullable: true, comment: "Tipo de pago de los productos en la factura", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "facturacompra_proveedor_FK",
                        column: x => x.IdProveedorFK,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUserFK = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TokenExpired = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TokenRevoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_User_IdUserFK",
                        column: x => x.IdUserFK,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "user_rol",
                columns: table => new
                {
                    IdUserFK = table.Column<int>(type: "int", nullable: false),
                    IdRolFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_rol", x => new { x.IdUserFK, x.IdRolFK });
                    table.ForeignKey(
                        name: "FK_user_rol_Rol_IdRolFK",
                        column: x => x.IdRolFK,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_rol_User_IdUserFK",
                        column: x => x.IdUserFK,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true, comment: "Nombre del producto", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Precio de venta del producto"),
                    UsoClinico = table.Column<string>(type: "enum('SI','NO')", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoBarras = table.Column<string>(type: "varchar(50)", nullable: true, comment: "Código de barras del producto", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Marca = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true, comment: "Nombre de la marca del producto", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Descripción del producto", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Presentacion = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true, comment: "Presentación del producto, si es que incluye sea desde tallas, tamaños, unidades entre otros", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalExistencias = table.Column<int>(type: "int", nullable: false, comment: "Cantidad o existencia total por producto"),
                    Categoria = table.Column<string>(type: "varchar(25)", precision: 10, scale: 2, nullable: true, comment: "Categoría de los productos en la factura", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdFacturaCompraFk = table.Column<int>(type: "int", nullable: false, comment: "Identificador de puenteo con la tabla de FacturaCompra")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "facturacompra_producto_FK",
                        column: x => x.IdFacturaCompraFk,
                        principalTable: "FacturaCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "FacturaVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador de una factura de venta")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaVenta = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha de la venta"),
                    IdEmpleadoFK = table.Column<int>(type: "int", nullable: false, comment: "Identificador de puenteo con la tabla de Empleado (Persona)"),
                    IdProductoFk = table.Column<int>(type: "int", nullable: false, comment: "Identificador de puenteo con la tabla de Producto"),
                    Cantidad = table.Column<int>(type: "int", nullable: false, comment: "Cantidad de productos"),
                    Iva = table.Column<int>(type: "int", nullable: false, comment: "IVA o comisión por compra, establecido por el gobierno"),
                    PrecioTotal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false, comment: "Precio total de la venta"),
                    TipoPago = table.Column<string>(type: "varchar(25)", nullable: true, comment: "Tipo de pago de los productos en la factura", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "facturaventa_producto_FK",
                        column: x => x.IdProductoFk,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "facturaventa_persona_FK",
                        column: x => x.IdEmpleadoFK,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "facturacompra_proveedor_FK",
                table: "FacturaCompra",
                column: "IdProveedorFK");

            migrationBuilder.CreateIndex(
                name: "facturaventa_persona_FK",
                table: "FacturaVenta",
                column: "IdEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "facturaventa_producto_FK",
                table: "FacturaVenta",
                column: "IdProductoFk");

            migrationBuilder.CreateIndex(
                name: "persona_unique",
                table: "Persona",
                columns: new[] { "Cedula", "Correo", "Telefono" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "facturacompra_producto_FK",
                table: "Producto",
                column: "IdFacturaCompraFk");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_IdUserFK",
                table: "RefreshTokens",
                column: "IdUserFK");

            migrationBuilder.CreateIndex(
                name: "IX_user_rol_IdRolFK",
                table: "user_rol",
                column: "IdRolFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturaVenta");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "user_rol");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "FacturaCompra");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
