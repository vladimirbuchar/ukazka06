using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class Culture14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] columns = new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Value", "Name", "IsDefault", "Priority", "IsActive", "IsEnvironmentCulture" };

            migrationBuilder.InsertData("Cb_Culture", columns, new object[] { Guid.NewGuid(), false, true, true, "za", "Zhuang, Chuang", "Saɯ cueŋƅ, Saw cuengh", false, 100, true, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
