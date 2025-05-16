using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unigis.PuntoVentas.BackEnd.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migracioninicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PuntoVentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Latitud = table.Column<decimal>(type: "decimal(10,7)", nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(10,7)", nullable: false),
                    Ventas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdZona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoVentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PuntoVentas_Zonas_IdZona",
                        column: x => x.IdZona,
                        principalTable: "Zonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PuntoVentas_IdZona",
                table: "PuntoVentas",
                column: "IdZona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PuntoVentas");

            migrationBuilder.DropTable(
                name: "Zonas");
        }
    }
}
