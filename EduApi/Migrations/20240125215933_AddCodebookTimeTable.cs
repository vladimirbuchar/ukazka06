using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCodebookTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "Cb_TimeTable",
                new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Name", "Value", "IsDefault", "Priority" },
                new object[]
                {
                    Guid.NewGuid(),
                    false,
                    true,
                    true,
                    "CODEBOOK_SELECT_VALUE",
                    "CODEBOOK_SELECT_VALUE",
                    "CODEBOOK_SELECT_VALUE",
                    true,
                    -1
                }
            );
            int priority = 0;
            for (int h = 0; h <= 23; h++)
            {
                string hour = h <= 9 ? string.Format("0{0}", h) : string.Format("{0}", h);
                for (int m = 0; m <= 55; m = m + 5)
                {
                    string minute = m <= 9 ? string.Format("0{0}", m) : string.Format("{0}", m);
                    string time = string.Format("{0}:{1}", hour, minute);
                    migrationBuilder.InsertData(
                        "Cb_TimeTable",
                        new string[]
                        {
                            "Id",
                            "IsDeleted",
                            "IsSystemObject",
                            "IsChanged",
                            "SystemIdentificator",
                            "Name",
                            "Value",
                            "IsDefault",
                            "Priority"
                        },
                        new object[] { Guid.NewGuid(), false, true, true, time, time, time, true, priority }
                    );

                    priority++;
                }
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
