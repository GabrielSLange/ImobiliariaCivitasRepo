using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace imobiliariaCivitas_api.Migrations
{
    public partial class TabelaUsuarioAcesso3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_usuario_tb_acesso_cd_acesso",
                table: "tb_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_acesso",
                table: "tb_acesso");

            migrationBuilder.RenameTable(
                name: "tb_acesso",
                newName: "tb_acessos");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "tb_usuario",
                newName: "senha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_acessos",
                table: "tb_acessos",
                column: "cd_acesso");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_usuario_tb_acessos_cd_acesso",
                table: "tb_usuario",
                column: "cd_acesso",
                principalTable: "tb_acessos",
                principalColumn: "cd_acesso",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_usuario_tb_acessos_cd_acesso",
                table: "tb_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_acessos",
                table: "tb_acessos");

            migrationBuilder.RenameTable(
                name: "tb_acessos",
                newName: "tb_acesso");

            migrationBuilder.RenameColumn(
                name: "senha",
                table: "tb_usuario",
                newName: "password");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_acesso",
                table: "tb_acesso",
                column: "cd_acesso");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_usuario_tb_acesso_cd_acesso",
                table: "tb_usuario",
                column: "cd_acesso",
                principalTable: "tb_acesso",
                principalColumn: "cd_acesso",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
