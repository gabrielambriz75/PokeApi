using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiPrimeraApi.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Usu");

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "Usu",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    ApPaterno = table.Column<string>(nullable: true),
                    ApMaterno = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: false),
                    Contrasena = table.Column<string>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    IdUcreo = table.Column<int>(nullable: false),
                    FechaModifico = table.Column<DateTime>(nullable: false),
                    IdUModifico = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "Usu");
        }
    }
}
