using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class RolePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "CreatePrivateCourse", table: "Cb_License");

            migrationBuilder.DropColumn(name: "MaximumBranch", table: "Cb_License");

            migrationBuilder.DropColumn(name: "MaximumCourse", table: "Cb_License");

            migrationBuilder.DropColumn(name: "MaximumUser", table: "Cb_License");

            migrationBuilder.DropColumn(name: "SendCourseInquiry", table: "Cb_License");

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Routes", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Edu_OrganizationRole_OrganizationRoleId",
                        column: x => x.OrganizationRoleId,
                        principalTable: "Edu_OrganizationRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_Permissions_Routes_RouteId", column: x => x.RouteId, principalTable: "Routes", principalColumn: "Id", onDelete: ReferentialAction.Cascade);
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Permissions_OrganizationRoleId", table: "Permissions", column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(name: "IX_Permissions_RouteId", table: "Permissions", column: "RouteId");

            migrationBuilder.CreateIndex(name: "IX_Permissions_SystemIdentificator", table: "Permissions", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(name: "IX_Routes_SystemIdentificator", table: "Routes", column: "SystemIdentificator", unique: true, filter: "[SystemIdentificator] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Permissions");

            migrationBuilder.DropTable(name: "Routes");

            migrationBuilder.AddColumn<bool>(name: "CreatePrivateCourse", table: "Cb_License", type: "bit", nullable: false, defaultValue: false);

            migrationBuilder.AddColumn<int>(name: "MaximumBranch", table: "Cb_License", type: "int", nullable: false, defaultValue: 0);

            migrationBuilder.AddColumn<int>(name: "MaximumCourse", table: "Cb_License", type: "int", nullable: false, defaultValue: 0);

            migrationBuilder.AddColumn<int>(name: "MaximumUser", table: "Cb_License", type: "int", nullable: false, defaultValue: 0);

            migrationBuilder.AddColumn<bool>(name: "SendCourseInquiry", table: "Cb_License", type: "bit", nullable: false, defaultValue: false);
        }
    }
}
