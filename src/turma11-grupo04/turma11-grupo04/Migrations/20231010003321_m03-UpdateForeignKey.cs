using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace turma11_grupo04.Migrations
{
    /// <inheritdoc />
    public partial class m03UpdateForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Cobrador_CobradorId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IdCobrador",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "idCliente",
                table: "Cobranca",
                newName: "CobradorId");

            migrationBuilder.RenameColumn(
                name: "IdCobrador",
                table: "Cobranca",
                newName: "ClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "CobradorId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Cobrador_CobradorId",
                table: "Cliente",
                column: "CobradorId",
                principalTable: "Cobrador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Cobrador_CobradorId",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "CobradorId",
                table: "Cobranca",
                newName: "idCliente");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Cobranca",
                newName: "IdCobrador");

            migrationBuilder.AlterColumn<int>(
                name: "CobradorId",
                table: "Cliente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdCobrador",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Cobrador_CobradorId",
                table: "Cliente",
                column: "CobradorId",
                principalTable: "Cobrador",
                principalColumn: "Id");
        }
    }
}
