using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudSimplesApiFiis.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FundosImobiliarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Papel = table.Column<string>(type: "VARCHAR", maxLength: 8, nullable: false),
                    NomeFundo = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    Administradora = table.Column<string>(type: "TEXT", nullable: true),
                    ValorPatrimonial = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    PatrimonioLiquido = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataIpo = table.Column<DateTime>(type: "DATE", nullable: false),
                    CotasEmitidas = table.Column<string>(type: "TEXT", nullable: true),
                    Cnpj = table.Column<string>(type: "TEXT", nullable: true),
                    PublicoAlvo = table.Column<string>(type: "TEXT", nullable: true),
                    TaxaAdministracao = table.Column<decimal>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundosImobiliarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaFundoImobiliario",
                columns: table => new
                {
                    CategoriasId = table.Column<int>(type: "INTEGER", nullable: false),
                    FundosImobiliariosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaFundoImobiliario", x => new { x.CategoriasId, x.FundosImobiliariosId });
                    table.ForeignKey(
                        name: "FK_CategoriaFundoImobiliario_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaFundoImobiliario_FundosImobiliarios_FundosImobiliariosId",
                        column: x => x.FundosImobiliariosId,
                        principalTable: "FundosImobiliarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaFundoImobiliario_FundosImobiliariosId",
                table: "CategoriaFundoImobiliario",
                column: "FundosImobiliariosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaFundoImobiliario");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "FundosImobiliarios");
        }
    }
}
