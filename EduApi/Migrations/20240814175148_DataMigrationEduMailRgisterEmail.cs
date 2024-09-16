using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class DataMigrationEduMailRgisterEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DECLARE @NewGuid UNIQUEIDENTIFIER;\r\nSET @NewGuid = NEWID();\r\n\r\nINSERT INTO [dbo].[Edu_Email]\r\n           ([Id]\r\n           ,[IsHtml]\r\n           ,[From]\r\n           ,[EmailTypeId]           \r\n           ,[IsDeleted]\r\n           ,[IsSystemObject])\r\n     VALUES\r\n           (@NewGuid\r\n           ,1\r\n           ,'info@flexiblelms.com'\r\n           ,(SELECT TOP(1) Id\r\n  FROM Cb_EmailType\r\n  WHERE SystemIdentificator =  'REGISTRATION_USER')\r\n           ,0\r\n           ,1)\r\n\r\n\t\t   INSERT INTO [dbo].[Edu_EmailTranslation]\r\n           ([Id]\r\n           ,[Subject]\r\n           ,[EmailBodyHtml]\r\n           ,[EmailBodyPlainText]\r\n           ,[IsDeleted]\r\n           ,[IsSystemObject]\r\n           \r\n           ,[CultureId],\r\n\t\t   [EmailId]\r\n           )\r\n     VALUES\r\n           (NEWID()\r\n           ,'Děkujeme Vám za registraci'\r\n           ,'<p>Dobrý den,</p> děkujeme Vám za registraci v aplikaci FlexibleLMS. <p>Pro dokončení registrace  je nutné kliknout na tento odkaz <a href =\"{activationLink}\">{activationLink}</a></p> <br /><br /> <p>S přáním hezkého dne</p> <p>Tým aplikace FlexibleLMS</p>'\r\n           ,'Dobrý den, děkujeme Vám za registraci v aplikaci FlexibleLMS. Pro dokončení registrace je nutné kliknout na tento odkaz {activationLink} S přáním hezkého dne Tým aplikace FlexibleLMS'\r\n           ,0\r\n           ,1\r\n\t\t   ,(select top(1) Id From Cb_Culture where SystemIdentificator = 'cs'),\r\n\t\t   @NewGuid\r\n           )");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
