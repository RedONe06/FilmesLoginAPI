using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Filme.Migrations
{
    public partial class MudandoFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Cinemas_CinemaFK",
                table: "Sessao",
                column: "CinemaFK",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Filmes_FilmeFK",
                table: "Sessao",
                column: "FilmeFK",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Cinemas_CinemaFK",
                table: "Sessao");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessao_Filmes_FilmeFK",
                table: "Sessao");

            migrationBuilder.RenameColumn(
                name: "FilmeFK",
                table: "Sessao",
                newName: "FilmeId");

            migrationBuilder.RenameColumn(
                name: "CinemaFK",
                table: "Sessao",
                newName: "CinemaId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessao_FilmeFK",
                table: "Sessao",
                newName: "IX_Sessao_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessao_CinemaFK",
                table: "Sessao",
                newName: "IX_Sessao_CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Cinemas_CinemaId",
                table: "Sessao",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessao_Filmes_FilmeId",
                table: "Sessao",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
