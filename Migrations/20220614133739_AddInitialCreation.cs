using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudSimplesApiFiis.Migrations
{
    public partial class AddInitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundosImobiliarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "VARCHAR2(6)", nullable: true),
                    ValorPatrimonial = table.Column<decimal>(type: "NUMBER", nullable: false),
                    PatrimonioLiquido = table.Column<decimal>(type: "NUMBER", nullable: false),
                    DataIpo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CotasEmitidas = table.Column<string>(type: "VARCHAR2(10)", nullable: false),
                    Cnpj = table.Column<string>(type: "VARCHAR2(30)", nullable: true),
                    PublicoAlvo = table.Column<string>(type: "VARCHAR2(30)", nullable: true),
                    TaxaAdministracao = table.Column<decimal>(type: "NUMBER", nullable: false),
                    Ativo = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundosImobiliarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundosImobiliarios");
        }
    }
}
