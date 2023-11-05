using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Eixo_2.Migrations
{
    public partial class RemoveImageFromCobradorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Cobradores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "Cobradores",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
