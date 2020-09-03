using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiPrimeraApi.Migrations
{
    public partial class NuevasPropiedadesUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CliendId",
                schema: "Usu",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "HashPassword",
                schema: "Usu",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SaltPass",
                schema: "Usu",
                table: "Usuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CliendId",
                schema: "Usu",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "HashPassword",
                schema: "Usu",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "SaltPass",
                schema: "Usu",
                table: "Usuario");
        }
    }
}
