using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCodebookCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Cb_Country SET IsDefault = 0");
            migrationBuilder.InsertData(
                "Cb_Country",
                new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Name", "Value", "IsDefault", "Priority", },
                new object[] { Guid.NewGuid(), false, true, true, "CODEBOOK_SELECT_VALUE", "CODEBOOK_SELECT_VALUE", "CODEBOOK_SELECT_VALUE", true, -1 }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
