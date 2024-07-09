using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCodebookDataAddressType : Migration
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
                "IsDefault",
                "Priority",
                "Name"
            };
            object[] PernamentAddress = new object[] { Guid.NewGuid(), false, true, true, "PERNAMENT_ADDRESS", false, 0, string.Empty };
            object[] MailingAddress = new object[] { Guid.NewGuid(), false, true, true, "MAILING_ADDRESS", false, 0, string.Empty };
            object[] registeredOfficeAddress = new object[]
            {
                Guid.NewGuid(),
                false,
                true,
                true,
                "REGISTERED_OFFICE_ADDRESS",
                false,
                0,
                string.Empty
            };
            object[] BillingAddress = new object[] { Guid.NewGuid(), false, true, true, "BILLING_ADDRESS", false, 0, string.Empty };
            object[] CbSelectValue = new object[] { Guid.NewGuid(), false, true, true, "CODEBOOK_SELECT_VALUE", false, 0, "CODEBOOK_SELECT_VALUE" };

            migrationBuilder.InsertData("Cb_AddressType", columns, PernamentAddress);
            migrationBuilder.InsertData("Cb_AddressType", columns, MailingAddress);
            migrationBuilder.InsertData("Cb_AddressType", columns, registeredOfficeAddress);
            migrationBuilder.InsertData("Cb_AddressType", columns, BillingAddress);
            migrationBuilder.InsertData("Cb_AddressType", columns, CbSelectValue);

            List<string> answerMode = new List<string>
            {
                "CODEBOOK_SELECT_VALUE",
                "TEXT",
                "SELECT_MANY_VIDEO",
                "SELECT_MANY_IMAGE",
                "YES_NO_TRUE_YES",
                "TEXT_MANUAL",
                "FILE_UPLOAD",
                "SELECT_MANY",
                "SELECT_ONE_IMAGE",
                "SELECT_ONE_AUDIO",
                "SELECT_ONE",
                "SELECT_MANY_AUDIO",
                "SELECT_ONE_VIDEO",
                "YES_NO_TRUE_NO"
            };
            int priority = -1;
            foreach (string item in answerMode)
            {
                migrationBuilder.InsertData(
                    "Cb_AnswerMode",
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
                    new object[] { Guid.NewGuid(), false, true, true, null, item, item, priority == -1, priority }
                );
                priority++;
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
