using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFinderApi.Migrations
{
    /// <inheritdoc />
    public partial class FixReportRelationsAndUniqueUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Reports_idEntity",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_idPet",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Pets_ReportCase",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Entities_ReportCase",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "idEntity",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "idPet",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportCase",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ReportCase",
                table: "Entities");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Entities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Entities",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_PetLost",
                table: "Reports",
                column: "PetLost");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportedBy",
                table: "Reports",
                column: "ReportedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_Email",
                table: "Entities",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_Identification",
                table: "Entities",
                column: "Identification",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entities_UserName",
                table: "Entities",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Entities_ReportedBy",
                table: "Reports",
                column: "ReportedBy",
                principalTable: "Entities",
                principalColumn: "idEntity",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Pets_PetLost",
                table: "Reports",
                column: "PetLost",
                principalTable: "Pets",
                principalColumn: "idPet",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Entities_ReportedBy",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Pets_PetLost",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_PetLost",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ReportedBy",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Entities_Email",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Entities_Identification",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Entities_UserName",
                table: "Entities");

            migrationBuilder.AddColumn<long>(
                name: "idEntity",
                table: "Reports",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "idPet",
                table: "Reports",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ReportCase",
                table: "Pets",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Entities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Entities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ReportCase",
                table: "Entities",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_idEntity",
                table: "Reports",
                column: "idEntity");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_idPet",
                table: "Reports",
                column: "idPet");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ReportCase",
                table: "Pets",
                column: "ReportCase");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_ReportCase",
                table: "Entities",
                column: "ReportCase");

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Reports_ReportCase",
                table: "Entities",
                column: "ReportCase",
                principalTable: "Reports",
                principalColumn: "Case");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Reports_ReportCase",
                table: "Pets",
                column: "ReportCase",
                principalTable: "Reports",
                principalColumn: "Case");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Entities_idEntity",
                table: "Reports",
                column: "idEntity",
                principalTable: "Entities",
                principalColumn: "idEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Pets_idPet",
                table: "Reports",
                column: "idPet",
                principalTable: "Pets",
                principalColumn: "idPet");
        }
    }
}
