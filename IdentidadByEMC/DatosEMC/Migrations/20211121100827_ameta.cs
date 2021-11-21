using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class ameta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsistenciaMeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    IdCompany = table.Column<int>(type: "INT", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Materia = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Turno = table.Column<int>(type: "INT", nullable: false),
                    EmailSend = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Grado = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Grupo = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    IdMod = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistenciaMeta", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsistenciaMeta");
        }
    }
}
