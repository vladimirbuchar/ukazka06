using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangeRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_User_Edu_UserRole_UserRoleId", table: "Edu_User");

            migrationBuilder.DropIndex(name: "IX_Edu_User_UserRoleId", table: "Edu_User");

            migrationBuilder.DropColumn(name: "UserRoleId", table: "Edu_User");

            migrationBuilder.AddColumn<string>(name: "UserRole", table: "Edu_User", type: "nvarchar(max)", nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "UserRole", table: "Edu_User");

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoleId",
                table: "Edu_User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_User_UserRoleId", table: "Edu_User", column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_User_Edu_UserRole_UserRoleId",
                table: "Edu_User",
                column: "UserRoleId",
                principalTable: "Edu_UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
