using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetFinderApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    Case = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RescueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PetLost = table.Column<long>(type: "bigint", nullable: false),
                    idPet = table.Column<long>(type: "bigint", nullable: true),
                    ReportedBy = table.Column<long>(type: "bigint", nullable: false),
                    idEntity = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.Case);
                });

            migrationBuilder.CreateTable(
                name: "entities",
                columns: table => new
                {
                    idEntity = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identification = table.Column<string>(type: "varchar(20)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Whatsapp = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportCase = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entities", x => x.idEntity);
                    table.ForeignKey(
                        name: "FK_entities_reports_ReportCase",
                        column: x => x.ReportCase,
                        principalTable: "reports",
                        principalColumn: "Case",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    idPet = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePet = table.Column<string>(type: "varchar(50)", nullable: false),
                    Specie = table.Column<string>(type: "varchar(20)", nullable: false),
                    Race = table.Column<string>(type: "varchar(80)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportCase = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pets", x => x.idPet);
                    table.ForeignKey(
                        name: "FK_pets_reports_ReportCase",
                        column: x => x.ReportCase,
                        principalTable: "reports",
                        principalColumn: "Case",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_entities_ReportCase",
                table: "entities",
                column: "ReportCase");

            migrationBuilder.CreateIndex(
                name: "IX_pets_ReportCase",
                table: "pets",
                column: "ReportCase");

            migrationBuilder.CreateIndex(
                name: "IX_reports_idEntity",
                table: "reports",
                column: "idEntity");

            migrationBuilder.CreateIndex(
                name: "IX_reports_idPet",
                table: "reports",
                column: "idPet");

            migrationBuilder.AddForeignKey(
                name: "FK_reports_entities_idEntity",
                table: "reports",
                column: "idEntity",
                principalTable: "entities",
                principalColumn: "idEntity",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reports_pets_idPet",
                table: "reports",
                column: "idPet",
                principalTable: "pets",
                principalColumn: "idPet",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entities_reports_ReportCase",
                table: "entities");

            migrationBuilder.DropForeignKey(
                name: "FK_pets_reports_ReportCase",
                table: "pets");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "entities");

            migrationBuilder.DropTable(
                name: "pets");
        }
    }
}
