using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class DeleteUserROle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "UserRole", table: "Edu_User");

            migrationBuilder.AddColumn<Guid>(name: "UserRoleDboId", table: "Edu_User", type: "uniqueidentifier", nullable: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_User_UserRoleDboId", table: "Edu_User", column: "UserRoleDboId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_User_Edu_UserRole_UserRoleDboId",
                table: "Edu_User",
                column: "UserRoleDboId",
                principalTable: "Edu_UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_User_Edu_UserRole_UserRoleDboId", table: "Edu_User");

            migrationBuilder.DropIndex(name: "IX_Edu_User_UserRoleDboId", table: "Edu_User");

            migrationBuilder.DropColumn(name: "UserRoleDboId", table: "Edu_User");

            migrationBuilder.AddColumn<string>(name: "UserRole", table: "Edu_User", type: "nvarchar(max)", nullable: true);
        }
    }
}
