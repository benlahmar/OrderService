using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.Infrastructure.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "commandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idclient = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_commandes_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Composants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduitId = table.Column<int>(type: "int", nullable: false),
                    quantite = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    idproduit = table.Column<int>(type: "int", nullable: false),
                    commandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Composants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Composants_commandes_commandId",
                        column: x => x.commandId,
                        principalTable: "commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Composants_Produit_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_commandes_ClientId",
                table: "commandes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Composants_commandId",
                table: "Composants",
                column: "commandId");

            migrationBuilder.CreateIndex(
                name: "IX_Composants_ProduitId",
                table: "Composants",
                column: "ProduitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Composants");

            migrationBuilder.DropTable(
                name: "commandes");

            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
