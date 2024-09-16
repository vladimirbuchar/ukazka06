using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class SendEmailDboAddIsError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(name: "ErrorMessage", table: "Edu_SendEmail", type: "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsError", table: "Edu_SendEmail", type: "bit", nullable: false, defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "ErrorMessage", table: "Edu_SendEmail");

            migrationBuilder.DropColumn(name: "IsError", table: "Edu_SendEmail");
        }
    }
}
