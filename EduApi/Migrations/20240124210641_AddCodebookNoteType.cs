using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCodebookNoteType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"INSERT INTO Cb_NoteType ([Id]
      ,[IsDeleted]
      ,[IsSystemObject]
      ,[IsChanged]
      ,[SystemIdentificator]
      ,[IsActive]
      ,[Name]
      ,[Value]
      ,[IsDefault]
      ,[Priority])
	  VALUES 
	  (NEWID(),0,1,1,null,1,'NOTE_TYPE_TEXT','NOTE_TYPE_TEXT',0,1)"
            );
            migrationBuilder.Sql(
                @"INSERT INTO Cb_NoteType ([Id]
      ,[IsDeleted]
      ,[IsSystemObject]
      ,[IsChanged]
      ,[SystemIdentificator]
      ,[IsActive]
      ,[Name]
      ,[Value]
      ,[IsDefault]
      ,[Priority])
	  VALUES 
	  (NEWID(),0,1,1,null,1,'NOTE_TYPE_DRAW','NOTE_TYPE_DRAW',0,2)"
            );

            migrationBuilder.Sql(
                @"INSERT INTO Cb_NoteType ([Id]
      ,[IsDeleted]
      ,[IsSystemObject]
      ,[IsChanged]
      ,[SystemIdentificator]
      ,[IsActive]
      ,[Name]
      ,[Value]
      ,[IsDefault]
      ,[Priority])
	  VALUES 
	  (NEWID(),0,1,1,null,1,'CODEBOOK_SELECT_VALUE','CODEBOOK_SELECT_VALUE',1,-1)"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
