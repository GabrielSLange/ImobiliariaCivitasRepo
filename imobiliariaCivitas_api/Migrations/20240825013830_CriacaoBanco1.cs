using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace imobiliariaCivitas_api.Migrations
{
    public partial class CriacaoBanco1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_imagem_tb_imovel_tb_imovelcd_imovel",
                table: "tb_imagem");

            migrationBuilder.DropIndex(
                name: "IX_tb_imagem_tb_imovelcd_imovel",
                table: "tb_imagem");

            migrationBuilder.DropColumn(
                name: "tb_imovelcd_imovel",
                table: "tb_imagem");

            migrationBuilder.CreateIndex(
                name: "IX_tb_imagem_cd_imovel",
                table: "tb_imagem",
                column: "cd_imovel");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_imagem_tb_imovel_cd_imovel",
                table: "tb_imagem",
                column: "cd_imovel",
                principalTable: "tb_imovel",
                principalColumn: "cd_imovel",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_imagem_tb_imovel_cd_imovel",
                table: "tb_imagem");

            migrationBuilder.DropIndex(
                name: "IX_tb_imagem_cd_imovel",
                table: "tb_imagem");

            migrationBuilder.AddColumn<int>(
                name: "tb_imovelcd_imovel",
                table: "tb_imagem",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_imagem_tb_imovelcd_imovel",
                table: "tb_imagem",
                column: "tb_imovelcd_imovel");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_imagem_tb_imovel_tb_imovelcd_imovel",
                table: "tb_imagem",
                column: "tb_imovelcd_imovel",
                principalTable: "tb_imovel",
                principalColumn: "cd_imovel");
        }
    }
}
