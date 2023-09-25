using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesAPI.Migrations
{
    /// <inheritdoc />
    public partial class producto2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClasificacionProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreClasificacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClasificacionProductos_CategoriasProductos_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriasProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaveProducto = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<float>(type: "real", nullable: false),
                    ClasificacionProductoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_CategoriasProductos_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriasProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_ClasificacionProductos_ClasificacionProductoId",
                        column: x => x.ClasificacionProductoId,
                        principalTable: "ClasificacionProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImgProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImgProductos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasProductos_NombreCategoria",
                table: "CategoriasProductos",
                column: "NombreCategoria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionProductos_CategoriaId",
                table: "ClasificacionProductos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionProductos_NombreClasificacion",
                table: "ClasificacionProductos",
                column: "NombreClasificacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionProductos_ProductoId",
                table: "ClasificacionProductos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ImgProductos_ProductoId",
                table: "ImgProductos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ClasificacionProductoId",
                table: "Productos",
                column: "ClasificacionProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Nombre",
                table: "Productos",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClasificacionProductos_Productos_ProductoId",
                table: "ClasificacionProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClasificacionProductos_CategoriasProductos_CategoriaId",
                table: "ClasificacionProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_CategoriasProductos_CategoriaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClasificacionProductos_Productos_ProductoId",
                table: "ClasificacionProductos");

            migrationBuilder.DropTable(
                name: "ImgProductos");

            migrationBuilder.DropTable(
                name: "CategoriasProductos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "ClasificacionProductos");
        }
    }
}
