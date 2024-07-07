using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddLicenseChangeDbo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_OrganizationSetting_Cb_License_LicenseOldId", table: "Edu_OrganizationSetting");

            migrationBuilder.DropIndex(name: "IX_Edu_OrganizationSetting_LicenseOldId", table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(name: "LicenseChange", table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(name: "LicenseOldId", table: "Edu_OrganizationSetting");

            migrationBuilder.CreateTable(
                name: "Edu_LicenseChange",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicenseChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenseOldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_LicenseChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_LicenseChange_Cb_License_LicenseOldId",
                        column: x => x.LicenseOldId,
                        principalTable: "Cb_License",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Edu_LicenseChange_Edu_Organization_OrganizationId", column: x => x.OrganizationId, principalTable: "Edu_Organization", principalColumn: "Id");
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_LicenseChange_LicenseOldId", table: "Edu_LicenseChange", column: "LicenseOldId");

            migrationBuilder.CreateIndex(name: "IX_Edu_LicenseChange_OrganizationId", table: "Edu_LicenseChange", column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_LicenseChange_SystemIdentificator",
                table: "Edu_LicenseChange",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Edu_LicenseChange");

            migrationBuilder.AddColumn<DateTime>(
                name: "LicenseChange",
                table: "Edu_OrganizationSetting",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.AddColumn<Guid>(name: "LicenseOldId", table: "Edu_OrganizationSetting", type: "uniqueidentifier", nullable: true);

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationSetting_LicenseOldId", table: "Edu_OrganizationSetting", column: "LicenseOldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_OrganizationSetting_Cb_License_LicenseOldId",
                table: "Edu_OrganizationSetting",
                column: "LicenseOldId",
                principalTable: "Cb_License",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }
    }
}
