using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AdOrganizationRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> userRoles = new List<string> { "ORGANIZATION_OWNER", "ORGANIZATION_ADMINISTRATOR", "LECTOR", "COURSE_ADMINISTATOR", "STUDENT", "COURSE_EDITOR" };

            string[] eduRole = new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator", "Priority" };

            foreach (string userRole in userRoles)
            {
                Guid userRoleGuid = Guid.NewGuid();

                object[] eduRoleValue = new object[] { Guid.NewGuid(), false, true, true, userRole, 0 };
                migrationBuilder.InsertData("Edu_OrganizationRole", eduRole, eduRoleValue);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
