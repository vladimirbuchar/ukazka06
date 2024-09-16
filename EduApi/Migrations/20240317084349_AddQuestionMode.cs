using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddQuestionMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"INSERT INTO Cb_QuestionMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,IsActive,Name,Value,IsDefault,Priority)
VALUES 
(NEWID(),0,1,1,'CODEBOOK_SELECT_VALUE',1,'CODEBOOK_SELECT_VALUE','CODEBOOK_SELECT_VALUE',0,0);

INSERT INTO Cb_QuestionMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,IsActive,Name,Value,IsDefault,Priority)
VALUES 
(NEWID(),0,1,1,'TEXT_QUESTION',1,'TEXT_QUESTION','TEXT_QUESTION',0,1);
INSERT INTO Cb_QuestionMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,IsActive,Name,Value,IsDefault,Priority)
VALUES 
(NEWID(),0,1,1,'AUDIO_QUESTION',1,'AUDIO_QUESTION','AUDIO_QUESTION',0,2)
INSERT INTO Cb_QuestionMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,IsActive,Name,Value,IsDefault,Priority)
VALUES 
(NEWID(),0,1,1,'VIDEO_QUESTION',1,'VIDEO_QUESTION','VIDEO_QUESTION',0,3)
INSERT INTO Cb_QuestionMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,IsActive,Name,Value,IsDefault,Priority)
VALUES 
(NEWID(),0,1,1,'IMAGE_QUESTION',1,'IMAGE_QUESTION','IMAGE_QUESTION',0,4)
"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
