using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class CourseMaterialFileRepositoryDbo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "LogoId", table: "Edu_OrganizationSetting");

            migrationBuilder.CreateTable(
                name: "Edu_CourseMaterialileRepository",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseMaterialileRepository", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseMaterialileRepository_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_CourseMaterialileRepository_Edu_CourseMaterial_CourseMaterialId",
                        column: x => x.CourseMaterialId,
                        principalTable: "Edu_CourseMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseMaterialileRepository_CourseMaterialId", table: "Edu_CourseMaterialileRepository", column: "CourseMaterialId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseMaterialileRepository_CultureId", table: "Edu_CourseMaterialileRepository", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseMaterialileRepository_SystemIdentificator",
                table: "Edu_CourseMaterialileRepository",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Edu_CourseMaterialileRepository");

            migrationBuilder.AddColumn<Guid>(
                name: "LogoId",
                table: "Edu_OrganizationSetting",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );
        }
    }
}
