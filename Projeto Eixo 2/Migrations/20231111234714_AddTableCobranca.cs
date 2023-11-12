using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Eixo_2.Migrations
{
    public partial class AddTableCobranca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobranças",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    CobradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobranças", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cobranças_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cobranças_Cobradores_CobradorId",
                        column: x => x.CobradorId,
                        principalTable: "Cobradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobranças_ClienteId",
                table: "Cobranças",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobranças_CobradorId",
                table: "Cobranças",
                column: "CobradorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobranças");
        }
    }
}
