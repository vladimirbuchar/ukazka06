using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class AddLicencePriority : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Cb_License SET Priority = 1 WHERE SystemIdentificator = 'FREE'");
            migrationBuilder.Sql("UPDATE Cb_License SET Priority = 2 WHERE SystemIdentificator = 'STANDARD'");
            migrationBuilder.Sql("UPDATE Cb_License SET Priority = 3 WHERE SystemIdentificator = 'PROFESIONAL'");
            migrationBuilder.Sql("UPDATE Cb_License SET Priority = 4 WHERE SystemIdentificator = 'ENTERPRISE'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
