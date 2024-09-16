using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class AdUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> userRoles = new List<string> { "SYSTEM", "REGISTERED_USER", "ADMINISTRATOR", "ANONYMOUS", };

            string[] eduRole = new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator" };

            foreach (string userRole in userRoles)
            {
                Guid userRoleGuid = Guid.NewGuid();

                object[] eduRoleValue = new object[] { Guid.NewGuid(), false, true, true, userRole };
                migrationBuilder.InsertData("Edu_UserRole", eduRole, eduRoleValue);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
