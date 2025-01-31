using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect__Bia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adoptator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locatie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCentru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacitate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Provenienta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipProvenienta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provenienta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Functie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CentruID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Angajat_Locatie_CentruID",
                        column: x => x.CentruID,
                        principalTable: "Locatie",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Copil",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNasterii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataIntrariiInSistem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProvenientaID = table.Column<int>(type: "int", nullable: true),
                    LocatieID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copil", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Copil_Locatie_LocatieID",
                        column: x => x.LocatieID,
                        principalTable: "Locatie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Copil_Provenienta_ProvenientaID",
                        column: x => x.ProvenientaID,
                        principalTable: "Provenienta",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Adoptie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CopilID = table.Column<int>(type: "int", nullable: true),
                    AdoptatorID = table.Column<int>(type: "int", nullable: true),
                    DataAdoptiei = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StareAdoptie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adoptie_Adoptator_AdoptatorID",
                        column: x => x.AdoptatorID,
                        principalTable: "Adoptator",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Adoptie_Copil_CopilID",
                        column: x => x.CopilID,
                        principalTable: "Copil",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoptie_AdoptatorID",
                table: "Adoptie",
                column: "AdoptatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptie_CopilID",
                table: "Adoptie",
                column: "CopilID");

            migrationBuilder.CreateIndex(
                name: "IX_Angajat_CentruID",
                table: "Angajat",
                column: "CentruID");

            migrationBuilder.CreateIndex(
                name: "IX_Copil_LocatieID",
                table: "Copil",
                column: "LocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Copil_ProvenientaID",
                table: "Copil",
                column: "ProvenientaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoptie");

            migrationBuilder.DropTable(
                name: "Angajat");

            migrationBuilder.DropTable(
                name: "Adoptator");

            migrationBuilder.DropTable(
                name: "Copil");

            migrationBuilder.DropTable(
                name: "Locatie");

            migrationBuilder.DropTable(
                name: "Provenienta");
        }
    }
}
