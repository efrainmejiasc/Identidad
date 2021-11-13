using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreArchivo = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    RutaArchivo = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    TipoArchivo = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Rfc = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Telefono = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Direccion = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Rol = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Rol);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Apellido = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Username = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Password = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Password2 = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    IdRol = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivo");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
