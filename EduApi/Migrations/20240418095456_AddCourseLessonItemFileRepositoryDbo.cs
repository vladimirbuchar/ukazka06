using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddCourseLessonItemFileRepositoryDbo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_CourseLessonItemFileRepository",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseLessonItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Edu_CourseLessonItemFileRepository", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseLessonItemFileRepository_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_CourseLessonItemFileRepository_Edu_CourseLessonItem_CourseLessonItemId",
                        column: x => x.CourseLessonItemId,
                        principalTable: "Edu_CourseLessonItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseLessonItemFileRepository_CourseLessonItemId", table: "Edu_CourseLessonItemFileRepository", column: "CourseLessonItemId");

            migrationBuilder.CreateIndex(name: "IX_Edu_CourseLessonItemFileRepository_CultureId", table: "Edu_CourseLessonItemFileRepository", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLessonItemFileRepository_SystemIdentificator",
                table: "Edu_CourseLessonItemFileRepository",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Edu_CourseLessonItemFileRepository");
        }
    }
}
