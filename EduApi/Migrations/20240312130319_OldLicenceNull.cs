using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class OldLicenceNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_OrganizationSetting_Cb_License_LicenseOldId", table: "Edu_OrganizationSetting");

            migrationBuilder.AlterColumn<Guid>(name: "LicenseOldId", table: "Edu_OrganizationSetting", type: "uniqueidentifier", nullable: true, oldClrType: typeof(Guid), oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_OrganizationSetting_Cb_License_LicenseOldId",
                table: "Edu_OrganizationSetting",
                column: "LicenseOldId",
                principalTable: "Cb_License",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_OrganizationSetting_Cb_License_LicenseOldId", table: "Edu_OrganizationSetting");

            migrationBuilder.AlterColumn<Guid>(
                name: "LicenseOldId",
                table: "Edu_OrganizationSetting",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_OrganizationSetting_Cb_License_LicenseOldId",
                table: "Edu_OrganizationSetting",
                column: "LicenseOldId",
                principalTable: "Cb_License",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
