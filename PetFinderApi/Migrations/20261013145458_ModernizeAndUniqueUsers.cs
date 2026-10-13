using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFinderApi.Migrations
{
    /// <inheritdoc />
    public partial class ModernizeAndUniqueUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Entities_Email",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Entities_Identification",
                table: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Entities_UserName",
                table: "Entities");

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
        }
    }
}
