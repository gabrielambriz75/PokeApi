using Microsoft.EntityFrameworkCore.Migrations;

namespace MiPrimeraApi.Migrations
{
    public partial class CambioPropiedadClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CliendId",
                schema: "Usu",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                schema: "Usu",
                table: "Usuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "Usu",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "CliendId",
                schema: "Usu",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
