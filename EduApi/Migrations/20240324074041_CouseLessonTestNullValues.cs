using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class CouseLessonTestNullValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_CourseLesson_Edu_CourseTest_CourseTestId", table: "Edu_CourseLesson");

            migrationBuilder.AlterColumn<Guid>(name: "CourseTestId", table: "Edu_CourseLesson", type: "uniqueidentifier", nullable: true, oldClrType: typeof(Guid), oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseLesson_Edu_CourseTest_CourseTestId",
                table: "Edu_CourseLesson",
                column: "CourseTestId",
                principalTable: "Edu_CourseTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_CourseLesson_Edu_CourseTest_CourseTestId", table: "Edu_CourseLesson");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseTestId",
                table: "Edu_CourseLesson",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseLesson_Edu_CourseTest_CourseTestId",
                table: "Edu_CourseLesson",
                column: "CourseTestId",
                principalTable: "Edu_CourseTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
