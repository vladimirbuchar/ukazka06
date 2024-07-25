using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class DeafultValueInCodebook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Cb_AddressType SET IsDefault  = 1 WHERE SystemIdentificator = 'CODEBOOK_SELECT_VALUE'");
            migrationBuilder.Sql("UPDATE Cb_CourseLessonItemTemplate SET IsDefault  = 1 WHERE SystemIdentificator = 'CODEBOOK_SELECT_VALUE'");
            migrationBuilder.Sql("UPDATE Cb_CourseStatus SET IsDefault  = 1 WHERE SystemIdentificator = 'CODEBOOK_SELECT_VALUE'");
            migrationBuilder.Sql("UPDATE Cb_CourseType SET IsDefault  = 1 WHERE SystemIdentificator = 'CODEBOOK_SELECT_VALUE'");
            migrationBuilder.Sql("UPDATE Cb_Email SET IsDefault  = 1 WHERE SystemIdentificator = 'CODEBOOK_SELECT_VALUE'");
            migrationBuilder.Sql("UPDATE Cb_GalleryItemType SET IsDefault  = 1 WHERE SystemIdentificator = 'CODEBOOK_SELECT_VALUE'");

            migrationBuilder.Sql("UPDATE Cb_License SET IsDefault  = 0 WHERE SystemIdentificator = 'ENTERPRISE'");
            migrationBuilder.Sql("UPDATE Cb_License SET IsDefault  = 0 WHERE SystemIdentificator = 'PROFESIONAL'");
            migrationBuilder.Sql("UPDATE Cb_License SET IsDefault  = 0 WHERE SystemIdentificator = 'STANDARD'");

            migrationBuilder.Sql("UPDATE Cb_NotificationType SET IsDefault  = 1 WHERE SystemIdentificator = 'CODEBOOK_SELECT_VALUE'");
            migrationBuilder.Sql("UPDATE Cb_QuestionMode SET IsDefault  = 1 WHERE SystemIdentificator = 'CODEBOOK_SELECT_VALUE'");
            migrationBuilder.Sql("UPDATE Cb_QuestionMode SET IsDefault  = 1 WHERE SystemIdentificator = 'CODEBOOK_SELECT_VALUE'");
            migrationBuilder.Sql("UPDATE Cb_TimeTable SET IsDefault  = 0 ");
            migrationBuilder.Sql("UPDATE Cb_TimeTable SET IsDefault  = 1 WHERE SystemIdentificator = 'CODEBOOK_SELECT_VALUE'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
