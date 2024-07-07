using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddAnswerFileRepositoryIdNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_TestQuestionAnswer_Edu_FileRepository_FileRepositoryId", table: "Edu_TestQuestionAnswer");

            migrationBuilder.AlterColumn<Guid>(
                name: "FileRepositoryId",
                table: "Edu_TestQuestionAnswer",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_TestQuestionAnswer_Edu_FileRepository_FileRepositoryId",
                table: "Edu_TestQuestionAnswer",
                column: "FileRepositoryId",
                principalTable: "Edu_FileRepository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_TestQuestionAnswer_Edu_FileRepository_FileRepositoryId", table: "Edu_TestQuestionAnswer");

            migrationBuilder.AlterColumn<Guid>(
                name: "FileRepositoryId",
                table: "Edu_TestQuestionAnswer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_TestQuestionAnswer_Edu_FileRepository_FileRepositoryId",
                table: "Edu_TestQuestionAnswer",
                column: "FileRepositoryId",
                principalTable: "Edu_FileRepository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
