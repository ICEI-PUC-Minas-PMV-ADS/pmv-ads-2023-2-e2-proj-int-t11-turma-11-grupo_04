using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace turma11_grupo04.Migrations
{
    /// <inheritdoc />
    public partial class m04UpdateCobrancaForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cobranca_ClienteId",
                table: "Cobranca",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobranca_CobradorId",
                table: "Cobranca",
                column: "CobradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobranca_Cliente_ClienteId",
                table: "Cobranca",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobranca_Cobrador_CobradorId",
                table: "Cobranca",
                column: "CobradorId",
                principalTable: "Cobrador",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobranca_Cliente_ClienteId",
                table: "Cobranca");

            migrationBuilder.DropForeignKey(
                name: "FK_Cobranca_Cobrador_CobradorId",
                table: "Cobranca");

            migrationBuilder.DropIndex(
                name: "IX_Cobranca_ClienteId",
                table: "Cobranca");

            migrationBuilder.DropIndex(
                name: "IX_Cobranca_CobradorId",
                table: "Cobranca");
        }
    }
}
