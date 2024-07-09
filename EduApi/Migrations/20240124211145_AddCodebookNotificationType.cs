using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCodebookNotificationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] column = new string[]
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
            };
            object[] values = new object[]
            {
                Guid.NewGuid(),
                false,
                true,
                true,
                "INVITE_TO_ORGANIZATION",
                "INVITE_TO_ORGANIZATION",
                "INVITE_TO_ORGANIZATION",
                false,
                0
            };
            migrationBuilder.InsertData("Cb_NotificationType", column, values);

            object[] valuesTerm = new object[]
            {
                Guid.NewGuid(),
                false,
                true,
                true,
                "ADD_STUDENT_TO_COURSE_TERM",
                "ADD_STUDENT_TO_COURSE_TERM",
                "ADD_STUDENT_TO_COURSE_TERM",
                false,
                0
            };
            migrationBuilder.InsertData("Cb_NotificationType", column, valuesTerm);

            object[] valuesDeault = new object[]
            {
                Guid.NewGuid(),
                false,
                true,
                true,
                "CODEBOOK_SELECT_VALUE",
                "CODEBOOK_SELECT_VALUE",
                "CODEBOOK_SELECT_VALUE",
                false,
                0
            };
            migrationBuilder.InsertData("Cb_NotificationType", column, valuesDeault);
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
