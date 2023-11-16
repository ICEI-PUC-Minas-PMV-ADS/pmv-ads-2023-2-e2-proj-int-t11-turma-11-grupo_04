using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Eixo_2.Migrations
{
    public partial class M01AddColumnPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Cobradores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Cobradores");
        }
    }
}
