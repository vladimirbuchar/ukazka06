using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangeKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "CourseTermDateFromId", table: "Cb_TimeTable");

            migrationBuilder.DropColumn(name: "CourseTermDateToId", table: "Cb_TimeTable");

            migrationBuilder.DropColumn(name: "CourseTermFromId", table: "Cb_TimeTable");

            migrationBuilder.DropColumn(name: "CourseTermToId", table: "Cb_TimeTable");

            migrationBuilder.DropColumn(name: "OrganizationStudyHourFromId", table: "Cb_TimeTable");

            migrationBuilder.DropColumn(name: "OrganizationStudyHourToId", table: "Cb_TimeTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseTermDateFromId",
                table: "Cb_TimeTable",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<Guid>(
                name: "CourseTermDateToId",
                table: "Cb_TimeTable",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<Guid>(
                name: "CourseTermFromId",
                table: "Cb_TimeTable",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<Guid>(name: "CourseTermToId", table: "Cb_TimeTable", type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationStudyHourFromId",
                table: "Cb_TimeTable",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationStudyHourToId",
                table: "Cb_TimeTable",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );
        }
    }
}
