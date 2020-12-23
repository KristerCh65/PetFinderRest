using Microsoft.EntityFrameworkCore.Migrations;

namespace PetFinderApi.Migrations
{
    public partial class secondMIgration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entities_reports_ReportCase",
                table: "entities");

            migrationBuilder.DropForeignKey(
                name: "FK_pets_reports_ReportCase",
                table: "pets");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_entities_idEntity",
                table: "reports");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_pets_idPet",
                table: "reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reports",
                table: "reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pets",
                table: "pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entities",
                table: "entities");

            migrationBuilder.RenameTable(
                name: "reports",
                newName: "Reports");

            migrationBuilder.RenameTable(
                name: "pets",
                newName: "Pets");

            migrationBuilder.RenameTable(
                name: "entities",
                newName: "Entities");

            migrationBuilder.RenameIndex(
                name: "IX_reports_idPet",
                table: "Reports",
                newName: "IX_Reports_idPet");

            migrationBuilder.RenameIndex(
                name: "IX_reports_idEntity",
                table: "Reports",
                newName: "IX_Reports_idEntity");

            migrationBuilder.RenameIndex(
                name: "IX_pets_ReportCase",
                table: "Pets",
                newName: "IX_Pets_ReportCase");

            migrationBuilder.RenameIndex(
                name: "IX_entities_ReportCase",
                table: "Entities",
                newName: "IX_Entities_ReportCase");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Entities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "Case");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "idPet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                table: "Entities",
                column: "idEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Reports_ReportCase",
                table: "Entities",
                column: "ReportCase",
                principalTable: "Reports",
                principalColumn: "Case",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Reports_ReportCase",
                table: "Pets",
                column: "ReportCase",
                principalTable: "Reports",
                principalColumn: "Case",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Entities_idEntity",
                table: "Reports",
                column: "idEntity",
                principalTable: "Entities",
                principalColumn: "idEntity",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Pets_idPet",
                table: "Reports",
                column: "idPet",
                principalTable: "Pets",
                principalColumn: "idPet",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entities_Reports_ReportCase",
                table: "Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Reports_ReportCase",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Entities_idEntity",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Pets_idPet",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Entities");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "reports");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "pets");

            migrationBuilder.RenameTable(
                name: "Entities",
                newName: "entities");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_idPet",
                table: "reports",
                newName: "IX_reports_idPet");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_idEntity",
                table: "reports",
                newName: "IX_reports_idEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_ReportCase",
                table: "pets",
                newName: "IX_pets_ReportCase");

            migrationBuilder.RenameIndex(
                name: "IX_Entities_ReportCase",
                table: "entities",
                newName: "IX_entities_ReportCase");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reports",
                table: "reports",
                column: "Case");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pets",
                table: "pets",
                column: "idPet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entities",
                table: "entities",
                column: "idEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_entities_reports_ReportCase",
                table: "entities",
                column: "ReportCase",
                principalTable: "reports",
                principalColumn: "Case",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pets_reports_ReportCase",
                table: "pets",
                column: "ReportCase",
                principalTable: "reports",
                principalColumn: "Case",
                onDelete: ReferentialAction.Restrict);

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
    }
}
