using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class EmailTypeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Cb_EmailType] ([Id],[IsDeleted],[IsSystemObject],[SystemIdentificator],[Name],[Value],[IsDefault],[Priority])" +
                "VALUES (NEWID(),0,1,'CODEBOOK_SELECT_VALUE','CODEBOOK_SELECT_VALUE','CODEBOOK_SELECT_VALUE',1,1)");

            migrationBuilder.Sql("INSERT INTO [dbo].[Cb_EmailType] ([Id],[IsDeleted],[IsSystemObject],[SystemIdentificator],[Name],[Value],[IsDefault],[Priority])" +
                "VALUES (NEWID(),0,1,'REGISTRATION_USER','REGISTRATION_USER','REGISTRATION_USER',0,2)");

            migrationBuilder.Sql("INSERT INTO [dbo].[Cb_EmailType] ([Id],[IsDeleted],[IsSystemObject],[SystemIdentificator],[Name],[Value],[IsDefault],[Priority])" +
                "VALUES (NEWID(),0,1,'PASSWORD_RESET','PASSWORD_RESET','PASSWORD_RESET',0,3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
