using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace imobiliariaCivitas_api.Migrations
{
    public partial class CriacaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_imovel",
                columns: table => new
                {
                    cd_imovel = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    criadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_imovel", x => x.cd_imovel);
                });

            migrationBuilder.CreateTable(
                name: "tb_imagem",
                columns: table => new
                {
                    cd_imagem = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cd_imovel = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    tb_imovelcd_imovel = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_imagem", x => x.cd_imagem);
                    table.ForeignKey(
                        name: "FK_tb_imagem_tb_imovel_tb_imovelcd_imovel",
                        column: x => x.tb_imovelcd_imovel,
                        principalTable: "tb_imovel",
                        principalColumn: "cd_imovel");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_imagem_tb_imovelcd_imovel",
                table: "tb_imagem",
                column: "tb_imovelcd_imovel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_imagem");

            migrationBuilder.DropTable(
                name: "tb_imovel");
        }
    }
}
