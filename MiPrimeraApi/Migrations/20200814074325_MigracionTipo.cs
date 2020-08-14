using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiPrimeraApi.Migrations
{
    public partial class MigracionTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Tip");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreo",
                schema: "Reg",
                table: "Region",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModifico",
                schema: "Reg",
                table: "Region",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdUCreo",
                schema: "Reg",
                table: "Region",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUModifico",
                schema: "Reg",
                table: "Region",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tipo",
                schema: "Tip",
                columns: table => new
                {
                    IdTipo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    IdUCreo = table.Column<int>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    IdUModifico = table.Column<int>(nullable: false),
                    FechaModifico = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.IdTipo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tipo",
                schema: "Tip");

            migrationBuilder.DropColumn(
                name: "FechaCreo",
                schema: "Reg",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "FechaModifico",
                schema: "Reg",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "IdUCreo",
                schema: "Reg",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "IdUModifico",
                schema: "Reg",
                table: "Region");
        }
    }
}
