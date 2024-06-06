using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_Edu_OrganizationStudyHour_ActiveFromId", table: "Edu_OrganizationStudyHour");

            migrationBuilder.DropIndex(name: "IX_Edu_OrganizationStudyHour_ActiveToId", table: "Edu_OrganizationStudyHour");

            migrationBuilder.DropIndex(name: "IX_Edu_CourseTermDate_TimeFromId", table: "Edu_CourseTermDate");

            migrationBuilder.DropIndex(name: "IX_Edu_CourseTermDate_TimeToId", table: "Edu_CourseTermDate");

            migrationBuilder.DropIndex(name: "IX_Edu_CourseTerm_TimeFromId", table: "Edu_CourseTerm");

            migrationBuilder.DropIndex(name: "IX_Edu_CourseTerm_TimeToId", table: "Edu_CourseTerm");

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationStudyHour_ActiveFromId", table: "Edu_OrganizationStudyHour", column: "ActiveFromId");

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationStudyHour_ActiveToId", table: "Edu_OrganizationStudyHour", column: "ActiveToId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTermDate_TimeFromId", table: "Edu_CourseTermDate", column: "TimeFromId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTermDate_TimeToId", table: "Edu_CourseTermDate", column: "TimeToId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTerm_TimeFromId", table: "Edu_CourseTerm", column: "TimeFromId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTerm_TimeToId", table: "Edu_CourseTerm", column: "TimeToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_Edu_OrganizationStudyHour_ActiveFromId", table: "Edu_OrganizationStudyHour");

            migrationBuilder.DropIndex(name: "IX_Edu_OrganizationStudyHour_ActiveToId", table: "Edu_OrganizationStudyHour");

            migrationBuilder.DropIndex(name: "IX_Edu_CourseTermDate_TimeFromId", table: "Edu_CourseTermDate");

            migrationBuilder.DropIndex(name: "IX_Edu_CourseTermDate_TimeToId", table: "Edu_CourseTermDate");

            migrationBuilder.DropIndex(name: "IX_Edu_CourseTerm_TimeFromId", table: "Edu_CourseTerm");

            migrationBuilder.DropIndex(name: "IX_Edu_CourseTerm_TimeToId", table: "Edu_CourseTerm");

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationStudyHour_ActiveFromId", table: "Edu_OrganizationStudyHour", column: "ActiveFromId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationStudyHour_ActiveToId", table: "Edu_OrganizationStudyHour", column: "ActiveToId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTermDate_TimeFromId", table: "Edu_CourseTermDate", column: "TimeFromId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTermDate_TimeToId", table: "Edu_CourseTermDate", column: "TimeToId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTerm_TimeFromId", table: "Edu_CourseTerm", column: "TimeFromId", unique: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseTerm_TimeToId", table: "Edu_CourseTerm", column: "TimeToId", unique: true);
        }
    }
}
