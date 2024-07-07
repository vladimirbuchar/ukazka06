using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddCodebookSendMessageType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "Cb_SendMessageType",
                new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Name", "Value", "IsDefault", "Priority" },
                new object[] { Guid.NewGuid(), false, true, true, "EMAIL", "EMAIL", "EMAIL", true, 1 }
            );
            migrationBuilder.InsertData(
                "Cb_SendMessageType",
                new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Name", "Value", "IsDefault", "Priority" },
                new object[] { Guid.NewGuid(), false, true, true, "SMS", "SMS", "SMS", true, 2 }
            );

            migrationBuilder.InsertData(
                "Cb_SendMessageType",
                new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Name", "Value", "IsDefault", "Priority" },
                new object[] { Guid.NewGuid(), false, true, true, "CODEBOOK_SELECT_VALUE", "CODEBOOK_SELECT_VALUE", "CODEBOOK_SELECT_VALUE", true, -1 }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
