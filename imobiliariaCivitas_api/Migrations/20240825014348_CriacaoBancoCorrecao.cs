using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace imobiliariaCivitas_api.Migrations
{
    public partial class CriacaoBancoCorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "tb_imagem",
                newName: "imageBase64");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageBase64",
                table: "tb_imagem",
                newName: "descricao");
        }
    }
}
