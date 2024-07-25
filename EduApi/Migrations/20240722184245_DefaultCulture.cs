using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class DefaultCulture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update Cb_Culture set IsDefault = 1 where SystemIdentificator  = 'CODEBOOK_SELECT_VALUE'");
            migrationBuilder.Sql("update Cb_Culture set IsEnvironmentCulture = 1 where SystemIdentificator  = 'cs'");
            migrationBuilder.Sql("update Cb_Culture set IsEnvironmentCulture = 1 where SystemIdentificator  = 'en'");
            migrationBuilder.Sql("update Cb_Culture set IsEnvironmentCulture = 1 where SystemIdentificator  = 'uk'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
