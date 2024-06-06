using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class enableclassiclogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserToken",
                table: "Edu_User");

            migrationBuilder.AddColumn<bool>(
                name: "AllowCLassicLogin",
                table: "Edu_User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowCLassicLogin",
                table: "Edu_User");

            migrationBuilder.AddColumn<string>(
                name: "UserToken",
                table: "Edu_User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
