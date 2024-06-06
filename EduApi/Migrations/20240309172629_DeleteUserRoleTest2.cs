using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class DeleteUserRoleTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_User_Edu_UserRole_UserRoleId", table: "Edu_User");

            migrationBuilder.AddForeignKey(name: "FK_Edu_User_Edu_UserRole_UserRoleId", table: "Edu_User", column: "UserRoleId", principalTable: "Edu_UserRole", principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_User_Edu_UserRole_UserRoleId", table: "Edu_User");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_User_Edu_UserRole_UserRoleId",
                table: "Edu_User",
                column: "UserRoleId",
                principalTable: "Edu_UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }
    }
}
