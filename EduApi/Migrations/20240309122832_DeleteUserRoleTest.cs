using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class DeleteUserRoleTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_User_Edu_UserRole_UserRoleDboId", table: "Edu_User");

            migrationBuilder.RenameColumn(name: "UserRoleDboId", table: "Edu_User", newName: "UserRoleId");

            migrationBuilder.RenameIndex(name: "IX_Edu_User_UserRoleDboId", table: "Edu_User", newName: "IX_Edu_User_UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_User_Edu_UserRole_UserRoleId",
                table: "Edu_User",
                column: "UserRoleId",
                principalTable: "Edu_UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_User_Edu_UserRole_UserRoleId", table: "Edu_User");

            migrationBuilder.RenameColumn(name: "UserRoleId", table: "Edu_User", newName: "UserRoleDboId");

            migrationBuilder.RenameIndex(name: "IX_Edu_User_UserRoleId", table: "Edu_User", newName: "IX_Edu_User_UserRoleDboId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_User_Edu_UserRole_UserRoleDboId",
                table: "Edu_User",
                column: "UserRoleDboId",
                principalTable: "Edu_UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }
    }
}
