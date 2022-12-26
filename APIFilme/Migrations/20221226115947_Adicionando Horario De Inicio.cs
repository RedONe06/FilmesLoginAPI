using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Filme.Migrations
{
    public partial class AdicionandoHorarioDeInicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HorarioDeInicio",
                table: "Sessoes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioDeInicio",
                table: "Sessoes");
        }
    }
}
