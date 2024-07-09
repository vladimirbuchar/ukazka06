using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_StudentTestSummaryAnswer_Edu_StudentTestSummaryQuestion_StudentTestSummaryQuestionDboId",
                table: "Edu_StudentTestSummaryAnswer"
            );

            migrationBuilder.DropIndex(
                name: "IX_Edu_StudentTestSummaryAnswer_StudentTestSummaryQuestionDboId",
                table: "Edu_StudentTestSummaryAnswer"
            );

            migrationBuilder.DropColumn(name: "StudentTestSummaryQuestionDboId", table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserTestImageAnswer",
                table: "Edu_StudentTestSummaryAnswer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true
            );

            migrationBuilder.AddColumn<Guid>(
                name: "StudentTestSummaryQuestionId",
                table: "Edu_StudentTestSummaryAnswer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryAnswer_StudentTestSummaryQuestionId",
                table: "Edu_StudentTestSummaryAnswer",
                column: "StudentTestSummaryQuestionId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_StudentTestSummaryAnswer_Edu_StudentTestSummaryQuestion_StudentTestSummaryQuestionId",
                table: "Edu_StudentTestSummaryAnswer",
                column: "StudentTestSummaryQuestionId",
                principalTable: "Edu_StudentTestSummaryQuestion",
                principalColumn: "Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_StudentTestSummaryAnswer_Edu_StudentTestSummaryQuestion_StudentTestSummaryQuestionId",
                table: "Edu_StudentTestSummaryAnswer"
            );

            migrationBuilder.DropIndex(name: "IX_Edu_StudentTestSummaryAnswer_StudentTestSummaryQuestionId", table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(name: "StudentTestSummaryQuestionId", table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.AlterColumn<string>(
                name: "UserTestImageAnswer",
                table: "Edu_StudentTestSummaryAnswer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "StudentTestSummaryQuestionDboId",
                table: "Edu_StudentTestSummaryAnswer",
                type: "uniqueidentifier",
                nullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryAnswer_StudentTestSummaryQuestionDboId",
                table: "Edu_StudentTestSummaryAnswer",
                column: "StudentTestSummaryQuestionDboId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_StudentTestSummaryAnswer_Edu_StudentTestSummaryQuestion_StudentTestSummaryQuestionDboId",
                table: "Edu_StudentTestSummaryAnswer",
                column: "StudentTestSummaryQuestionDboId",
                principalTable: "Edu_StudentTestSummaryQuestion",
                principalColumn: "Id"
            );
        }
    }
}
