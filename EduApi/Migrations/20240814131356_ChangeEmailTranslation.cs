using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEmailTranslation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cb_EmailTranslation_Cb_Culture_CultureId",
                table: "Cb_EmailTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_Cb_EmailTranslation_Edu_Email_EmailDboId",
                table: "Cb_EmailTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cb_EmailTranslation",
                table: "Cb_EmailTranslation");

            migrationBuilder.RenameTable(
                name: "Cb_EmailTranslation",
                newName: "Edu_EmailTranslation");

            migrationBuilder.RenameIndex(
                name: "IX_Cb_EmailTranslation_SystemIdentificator",
                table: "Edu_EmailTranslation",
                newName: "IX_Edu_EmailTranslation_SystemIdentificator");

            migrationBuilder.RenameIndex(
                name: "IX_Cb_EmailTranslation_EmailDboId",
                table: "Edu_EmailTranslation",
                newName: "IX_Edu_EmailTranslation_EmailDboId");

            migrationBuilder.RenameIndex(
                name: "IX_Cb_EmailTranslation_CultureId",
                table: "Edu_EmailTranslation",
                newName: "IX_Edu_EmailTranslation_CultureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Edu_EmailTranslation",
                table: "Edu_EmailTranslation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_EmailTranslation_Cb_Culture_CultureId",
                table: "Edu_EmailTranslation",
                column: "CultureId",
                principalTable: "Cb_Culture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_EmailTranslation_Edu_Email_EmailDboId",
                table: "Edu_EmailTranslation",
                column: "EmailDboId",
                principalTable: "Edu_Email",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_EmailTranslation_Cb_Culture_CultureId",
                table: "Edu_EmailTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_EmailTranslation_Edu_Email_EmailDboId",
                table: "Edu_EmailTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Edu_EmailTranslation",
                table: "Edu_EmailTranslation");

            migrationBuilder.RenameTable(
                name: "Edu_EmailTranslation",
                newName: "Cb_EmailTranslation");

            migrationBuilder.RenameIndex(
                name: "IX_Edu_EmailTranslation_SystemIdentificator",
                table: "Cb_EmailTranslation",
                newName: "IX_Cb_EmailTranslation_SystemIdentificator");

            migrationBuilder.RenameIndex(
                name: "IX_Edu_EmailTranslation_EmailDboId",
                table: "Cb_EmailTranslation",
                newName: "IX_Cb_EmailTranslation_EmailDboId");

            migrationBuilder.RenameIndex(
                name: "IX_Edu_EmailTranslation_CultureId",
                table: "Cb_EmailTranslation",
                newName: "IX_Cb_EmailTranslation_CultureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cb_EmailTranslation",
                table: "Cb_EmailTranslation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cb_EmailTranslation_Cb_Culture_CultureId",
                table: "Cb_EmailTranslation",
                column: "CultureId",
                principalTable: "Cb_Culture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cb_EmailTranslation_Edu_Email_EmailDboId",
                table: "Cb_EmailTranslation",
                column: "EmailDboId",
                principalTable: "Edu_Email",
                principalColumn: "Id");
        }
    }
}
