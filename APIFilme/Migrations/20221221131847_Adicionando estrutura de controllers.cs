using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Filme.Migrations
{
    public partial class Adicionandoestruturadecontrollers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gerentes",
                table: "Gerentes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Enderecos_EnderecoFK",
                table: "Cinemas",
                column: "EnderecoFK",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteFK",
                table: "Cinemas",
                column: "GerenteFK",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaFK",
                table: "Sessoes",
                column: "CinemaFK",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_FilmeFK",
                table: "Sessoes",
                column: "FilmeFK",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Enderecos_EnderecoFK",
                table: "Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteFK",
                table: "Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaFK",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_FilmeFK",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gerentes",
                table: "Gerentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Sessoes",
                newName: "Sessao");

            migrationBuilder.RenameTable(
                name: "Gerentes",
                newName: "Gerente");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Endereco");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_FilmeFK",
                table: "Sessoes",
                newName: "IX_Sessao_FilmeFK");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_CinemaFK",
                table: "Sessao",
                newName: "IX_Sessao_CinemaFK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessao",
                table: "Sessoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gerente",
                table: "Gerente",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Endereco_EnderecoFK",
                table: "Cinemas",
                column: "EnderecoFK",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerente_GerenteFK",
                table: "Cinemas",
                column: "GerenteFK",
                principalTable: "Gerente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
