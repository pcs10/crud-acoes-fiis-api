using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudSimplesApiFiis.Migrations
{
    public partial class AlterCampoModelFundoImobiliario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
             * Renomeação do campo Nome alterando pra Papel
             * Inserção de novos campos: Nome do fundo, Administradora e Categoria
             */
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "FundosImobiliarios",
                newName: "Papel");

            migrationBuilder.AddColumn<string>(
                name: "Administradora",
                table: "FundosImobiliarios",
                type: "VARCHAR(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "FundosImobiliarios",
                type: "VARCHAR(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFundo",
                table: "FundosImobiliarios",
                type: "VARCHAR(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Administradora",
                table: "FundosImobiliarios");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "FundosImobiliarios");

            migrationBuilder.DropColumn(
                name: "NomeFundo",
                table: "FundosImobiliarios");

            migrationBuilder.RenameColumn(
                name: "Papel",
                table: "FundosImobiliarios",
                newName: "Nome");

        }
    }
}
