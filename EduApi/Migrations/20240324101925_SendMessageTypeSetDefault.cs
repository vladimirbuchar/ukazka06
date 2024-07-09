using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SendMessageTypeSetDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE [flexiblelms3].[dbo].Cb_SendMessageType SET IsDefault = 0 WHERE SystemIdentificator = 'EMAIL' OR SystemIdentificator = 'SMS'"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
