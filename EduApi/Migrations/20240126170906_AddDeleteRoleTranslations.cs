using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddDeleteRoleTranslations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Edu_OrganizationRoleTranslation");

            migrationBuilder.DropTable(name: "Edu_UserRoleTranslation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_OrganizationRoleTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_OrganizationRoleTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationRoleTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationRoleTranslation_Edu_OrganizationRole_OrganizationRoleId",
                        column: x => x.OrganizationRoleId,
                        principalTable: "Edu_OrganizationRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Edu_UserRoleTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_UserRoleTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_UserRoleTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_UserRoleTranslation_Edu_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "Edu_UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationRoleTranslation_CultureId", table: "Edu_OrganizationRoleTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(name: "IX_Edu_OrganizationRoleTranslation_OrganizationRoleId", table: "Edu_OrganizationRoleTranslation", column: "OrganizationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationRoleTranslation_SystemIdentificator",
                table: "Edu_OrganizationRoleTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_UserRoleTranslation_CultureId", table: "Edu_UserRoleTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_UserRoleTranslation_SystemIdentificator",
                table: "Edu_UserRoleTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_UserRoleTranslation_UserRoleId", table: "Edu_UserRoleTranslation", column: "UserRoleId");
        }
    }
}
