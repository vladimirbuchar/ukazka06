using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCodebookCourseLessonItemTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"INSERT INTO Cb_CourseLessonItemTemplate(Id,IsDeleted,IsSystemObject,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive)
VALUES (NEWID(),0,1,'YOUTUBE','YOUTUBE','YOUTUBE',0,0,1);
INSERT INTO Cb_CourseLessonItemTemplate(Id,IsDeleted,IsSystemObject,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive)
VALUES (NEWID(),0,1,'VIDEO','VIDEO','VIDEO',0,0,1);
INSERT INTO Cb_CourseLessonItemTemplate(Id,IsDeleted,IsSystemObject,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive)
VALUES (NEWID(),0,1,'AUDIO','AUDIO','AUDIO',0,0,1);
"
            );

            migrationBuilder.Sql(
                @"INSERT INTO Cb_CourseLessonItemTemplate(Id,IsDeleted,IsSystemObject,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive)
VALUES (NEWID(),0,1,'BASIC_TEMPLATE_IMAGE','BASIC_TEMPLATE_IMAGE','BASIC_TEMPLATE_IMAGE',0,0,1);
INSERT INTO Cb_CourseLessonItemTemplate(Id,IsDeleted,IsSystemObject,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive)
VALUES (NEWID(),0,1,'BASIC_TEMPLATE','BASIC_TEMPLATE','BASIC_TEMPLATE',0,0,1);
INSERT INTO Cb_CourseLessonItemTemplate(Id,IsDeleted,IsSystemObject,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive)
VALUES (NEWID(),0,1,'POWER_POINT','POWER_POINT','POWER_POINT',0,0,1);

INSERT INTO Cb_CourseLessonItemTemplate(Id,IsDeleted,IsSystemObject,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive)
VALUES (NEWID(),0,1,'CODEBOOK_SELECT_VALUE','CODEBOOK_SELECT_VALUE','CODEBOOK_SELECT_VALUE',0,0,1);
"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
