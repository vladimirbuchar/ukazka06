using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMailSettigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("SmtpServerPort", "Edu_OrganizationSetting");
            migrationBuilder.AddColumn<int>(name: "SmtpServerPort", table: "Edu_OrganizationSetting", type: "int", nullable: false, defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SmtpServerPort",
                table: "Edu_OrganizationSetting",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int"
            );
        }
    }
}
