using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turma11_grupo04.Migrations
{
    /// <inheritdoc />
    public partial class M01AddTableCobrador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "Senha",
            table: "Cobrador",
            nullable: false);

            migrationBuilder.AddColumn<string>(
            name: "ConfirmaSenha",
            table: "Cobrador",
            nullable: false);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobranca");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Cobrador");
        }
    }
}
