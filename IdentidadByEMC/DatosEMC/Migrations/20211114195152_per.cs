using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class per : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMateria = table.Column<string>(type: "VARCHAR(80)", nullable: true),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Dni = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Apellido = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Matricula = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Rh = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Grado = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Grupo = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Empresa = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    Foto = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    Qr = table.Column<string>(type: "VARCHAR(8000)", nullable: true),
                    Turno = table.Column<int>(type: "INT", nullable: false),
                    Identificador = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    PathQr = table.Column<string>(type: "VARCHAR(8000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Dni);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
