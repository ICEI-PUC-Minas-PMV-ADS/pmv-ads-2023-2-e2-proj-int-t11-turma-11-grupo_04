using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Eixo_2.Migrations
{
    public partial class MColocandoMsgDeEmailValido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoStatus",
                table: "Cobranca",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Pagamento",
                table: "Cobranca",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusCobranca",
                table: "Cobranca",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoStatus",
                table: "Cobranca");

            migrationBuilder.DropColumn(
                name: "Pagamento",
                table: "Cobranca");

            migrationBuilder.DropColumn(
                name: "StatusCobranca",
                table: "Cobranca");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clientes");
        }
    }
}
