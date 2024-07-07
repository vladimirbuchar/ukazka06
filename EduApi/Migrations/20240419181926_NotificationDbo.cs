using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class NotificationDbo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "ObjectId", table: "Edu_Notification");

            migrationBuilder.AlterColumn<Guid>(name: "OrganizationId", table: "Edu_Notification", type: "uniqueidentifier", nullable: true, oldClrType: typeof(Guid), oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(name: "CourseTermId", table: "Edu_Notification", type: "uniqueidentifier", nullable: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_Notification_CourseTermId", table: "Edu_Notification", column: "CourseTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Notification_Edu_CourseTerm_CourseTermId",
                table: "Edu_Notification",
                column: "CourseTermId",
                principalTable: "Edu_CourseTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_Notification_Edu_CourseTerm_CourseTermId", table: "Edu_Notification");

            migrationBuilder.DropIndex(name: "IX_Edu_Notification_CourseTermId", table: "Edu_Notification");

            migrationBuilder.DropColumn(name: "CourseTermId", table: "Edu_Notification");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizationId",
                table: "Edu_Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AddColumn<Guid>(name: "ObjectId", table: "Edu_Notification", type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
