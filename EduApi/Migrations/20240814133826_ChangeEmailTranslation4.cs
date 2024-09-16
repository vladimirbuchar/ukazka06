using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEmailTranslation4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmailDboId",
                table: "Edu_EmailTranslation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmailId",
                table: "Edu_EmailTranslation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Edu_EmailTranslation_EmailDboId",
                table: "Edu_EmailTranslation",
                column: "EmailDboId");

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
                name: "FK_Edu_EmailTranslation_Edu_Email_EmailDboId",
                table: "Edu_EmailTranslation");

            migrationBuilder.DropIndex(
                name: "IX_Edu_EmailTranslation_EmailDboId",
                table: "Edu_EmailTranslation");

            migrationBuilder.DropColumn(
                name: "EmailDboId",
                table: "Edu_EmailTranslation");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Edu_EmailTranslation");
        }
    }
}
