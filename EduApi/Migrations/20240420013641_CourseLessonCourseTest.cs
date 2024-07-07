using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class CourseLessonCourseTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_Edu_CourseLesson_CourseTestId", table: "Edu_CourseLesson");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseLessonId",
                table: "Edu_CourseTest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseLesson_CourseTestId", table: "Edu_CourseLesson", column: "CourseTestId", unique: true, filter: "[CourseTestId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_Edu_CourseLesson_CourseTestId", table: "Edu_CourseLesson");

            migrationBuilder.DropColumn(name: "CourseLessonId", table: "Edu_CourseTest");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseLesson_CourseTestId", table: "Edu_CourseLesson", column: "CourseTestId");
        }
    }
}
