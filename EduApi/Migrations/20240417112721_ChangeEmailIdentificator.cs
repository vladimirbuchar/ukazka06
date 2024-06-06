using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangeEmailIdentificator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE   Cb_Email SET SystemIdentificator  = 'REGISTRATION_USER_cs' where SystemIdentificator = 'REGISTRATION_USER_cs-CZ'");
            migrationBuilder.Sql("UPDATE Cb_Email SET SystemIdentificator  = 'PASSWORD_RESET_cs' where SystemIdentificator = 'PASSWORD_RESET_cs-CZ'");
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
