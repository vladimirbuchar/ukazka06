using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCodebookLicenseStandard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] columns = new string[]
            {
                "Id",
                "IsDeleted",
                "IsSystemObject",
                "IsChanged",
                "SystemIdentificator",
                "Name",
                "Value",
                "IsDefault",
                "MaximumBranch",
                "MaximumCourse",
                "MounthPrice",
                "OneYearSale",
                "SendCourseInquiry",
                "CreatePrivateCourse",
                "Priority",
                "MaximumUser"
            };

            object[] dataStandard = new object[] { Guid.NewGuid(), false, true, true, "STANDARD", "STANDARD_LICENSE", "STANDARD_LICENSE", true, 25, 25, 199, 5, false, false, 3, 250 };

            migrationBuilder.InsertData("Cb_License", columns, dataStandard);
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
