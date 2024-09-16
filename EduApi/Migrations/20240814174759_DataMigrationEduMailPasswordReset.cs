using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class DataMigrationEduMailPasswordReset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DECLARE @NewGuid UNIQUEIDENTIFIER;\r\nSET @NewGuid = NEWID();\r\n\r\nINSERT INTO [dbo].[Edu_Email]\r\n           ([Id]\r\n           ,[IsHtml]\r\n           ,[From]\r\n           ,[EmailTypeId]           \r\n           ,[IsDeleted]\r\n           ,[IsSystemObject])\r\n     VALUES\r\n           (@NewGuid\r\n           ,1\r\n           ,'info@flexiblelms.com'\r\n           ,(SELECT TOP(1) Id\r\n  FROM Cb_EmailType\r\n  WHERE SystemIdentificator =  'PASSWORD_RESET')\r\n           ,0\r\n           ,1)\r\n\r\n\t\t   INSERT INTO [dbo].[Edu_EmailTranslation]\r\n           ([Id]\r\n           ,[Subject]\r\n           ,[EmailBodyHtml]\r\n           ,[EmailBodyPlainText]\r\n           ,[IsDeleted]\r\n           ,[IsSystemObject]\r\n           \r\n           ,[CultureId],\r\n\t\t   [EmailId]\r\n           )\r\n     VALUES\r\n           (NEWID()\r\n           ,'Zapomenuté heslo'\r\n           ,'<p>Dobrý den,</p><p>Na Vašem účtu jsme zaregistrovali požadavek na změnu hesla. Pro nastavení nového hesla klikněte na tento odkaz <a href = \"{passwordResetLink}\">{passwordResetLink}</a>. Pokud jste o změnu hesla nežádali tento email ignorujte.</p> <p>S přáním hezkého dne</p><br /> <p>Tým aplikace FlexibleLMS</p>'\r\n           ,'Dobrý den,Na Vašem účtu jsme zaregistrovali požadavek na změnu hesla. Pro nastavení nového hesla klikněte na tento odkaz {passwordResetLink}. Pokud jste o změnu hesla nežádali tento email ignorujte. S přáním hezkého dne Tým aplikace FlexibleLMS'\r\n           ,0\r\n           ,1\r\n\t\t   ,(select top(1) Id From Cb_Culture where SystemIdentificator = 'cs'),\r\n\t\t   @NewGuid\r\n           )\r\n\r\n\r\n\r\n\r\n\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
