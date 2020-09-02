using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GDev.Data.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DiaCadastro = table.Column<DateTime>(nullable: false),
                    DiaAlteracao = table.Column<DateTime>(nullable: true),
                    RAZAO_SOCIAL = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MODULO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DiaCadastro = table.Column<DateTime>(nullable: false),
                    DiaAlteracao = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODULO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ACESSO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DiaCadastro = table.Column<DateTime>(nullable: false),
                    DiaAlteracao = table.Column<DateTime>(nullable: true),
                    ModuloId = table.Column<string>(nullable: false),
                    ClienteId = table.Column<string>(nullable: false),
                    URL = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    TOKEN = table.Column<string>(type: "VARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACESSO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ACESSO_EMPRESA_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "EMPRESA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ACESSO_MODULO_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "MODULO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACESSO_ClienteId",
                table: "ACESSO",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ACESSO_ModuloId",
                table: "ACESSO",
                column: "ModuloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACESSO");

            migrationBuilder.DropTable(
                name: "EMPRESA");

            migrationBuilder.DropTable(
                name: "MODULO");
        }
    }
}
