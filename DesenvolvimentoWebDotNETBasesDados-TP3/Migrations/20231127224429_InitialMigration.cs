using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesenvolvimentoWebDotNETBasesDados_TP3.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aventureiro",
                columns: table => new
                {
                    AventureiroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aventureiro", x => x.AventureiroID);
                });

            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    EspecialidadeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaConhecimento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.EspecialidadeID);
                });

            migrationBuilder.CreateTable(
                name: "Investidura",
                columns: table => new
                {
                    InvestiduraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AventureiroID = table.Column<int>(type: "int", nullable: false),
                    EspecialidadeID = table.Column<int>(type: "int", nullable: false),
                    DataInvestidura = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investidura", x => x.InvestiduraID);
                    table.ForeignKey(
                        name: "FK_Investidura_Aventureiro_AventureiroID",
                        column: x => x.AventureiroID,
                        principalTable: "Aventureiro",
                        principalColumn: "AventureiroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Investidura_Especialidade_EspecialidadeID",
                        column: x => x.EspecialidadeID,
                        principalTable: "Especialidade",
                        principalColumn: "EspecialidadeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investidura_AventureiroID",
                table: "Investidura",
                column: "AventureiroID");

            migrationBuilder.CreateIndex(
                name: "IX_Investidura_EspecialidadeID",
                table: "Investidura",
                column: "EspecialidadeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investidura");

            migrationBuilder.DropTable(
                name: "Aventureiro");

            migrationBuilder.DropTable(
                name: "Especialidade");
        }
    }
}
