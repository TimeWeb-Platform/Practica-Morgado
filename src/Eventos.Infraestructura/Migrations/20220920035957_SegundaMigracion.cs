using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventos.Infraestructura.Migrations
{
    public partial class SegundaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitud",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitud",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoOrigen",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TipoOrigen",
                table: "Eventos");
        }
    }
}
