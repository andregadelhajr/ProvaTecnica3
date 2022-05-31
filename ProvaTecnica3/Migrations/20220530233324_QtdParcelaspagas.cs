using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvaTecnica3.Migrations
{
    public partial class QtdParcelaspagas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "QtdParcelaspagas",
                table: "Emprestimo",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtdParcelaspagas",
                table: "Emprestimo");
        }
    }
}
