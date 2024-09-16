using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEmailNotOrganization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Email_Edu_Organization_OrganizationId",
                table: "Edu_Email");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizationId",
                table: "Edu_Email",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Email_Edu_Organization_OrganizationId",
                table: "Edu_Email",
                column: "OrganizationId",
                principalTable: "Edu_Organization",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Email_Edu_Organization_OrganizationId",
                table: "Edu_Email");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizationId",
                table: "Edu_Email",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Email_Edu_Organization_OrganizationId",
                table: "Edu_Email",
                column: "OrganizationId",
                principalTable: "Edu_Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
