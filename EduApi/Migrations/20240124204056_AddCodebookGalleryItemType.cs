using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCodebookGalleryItemType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
INSERT INTO Cb_GalleryItemType(Id,IsDeleted,IsSystemObject,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive)
VALUES (NEWID(),0,1,'CODEBOOK_SELECT_VALUE','CODEBOOK_SELECT_VALUE','CODEBOOK_SELECT_VALUE',0,0,1);
"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
