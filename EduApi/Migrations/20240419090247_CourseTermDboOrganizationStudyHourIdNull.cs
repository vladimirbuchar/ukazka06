using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CourseTermDboOrganizationStudyHourIdNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_CourseTerm_Edu_OrganizationStudyHour_OrganizationStudyHourId", table: "Edu_CourseTerm");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizationStudyHourId",
                table: "Edu_CourseTerm",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTerm_Edu_OrganizationStudyHour_OrganizationStudyHourId",
                table: "Edu_CourseTerm",
                column: "OrganizationStudyHourId",
                principalTable: "Edu_OrganizationStudyHour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_CourseTerm_Edu_OrganizationStudyHour_OrganizationStudyHourId", table: "Edu_CourseTerm");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizationStudyHourId",
                table: "Edu_CourseTerm",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTerm_Edu_OrganizationStudyHour_OrganizationStudyHourId",
                table: "Edu_CourseTerm",
                column: "OrganizationStudyHourId",
                principalTable: "Edu_OrganizationStudyHour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
