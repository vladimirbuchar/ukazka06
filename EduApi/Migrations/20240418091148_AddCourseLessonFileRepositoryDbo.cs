using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCourseLessonFileRepositoryDbo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "PowerPointFile", table: "Edu_CourseLesson");

            migrationBuilder.CreateTable(
                name: "Edu_CourseLessonFileRepository",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseLessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Edu_CourseLessonFileRepository", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseLessonFileRepository_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_CourseLessonFileRepository_Edu_CourseLesson_CourseLessonId",
                        column: x => x.CourseLessonId,
                        principalTable: "Edu_CourseLesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLessonFileRepository_CourseLessonId",
                table: "Edu_CourseLessonFileRepository",
                column: "CourseLessonId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLessonFileRepository_CultureId",
                table: "Edu_CourseLessonFileRepository",
                column: "CultureId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLessonFileRepository_SystemIdentificator",
                table: "Edu_CourseLessonFileRepository",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Edu_CourseLessonFileRepository");

            migrationBuilder.AddColumn<string>(name: "PowerPointFile", table: "Edu_CourseLesson", type: "nvarchar(max)", nullable: true);
        }
    }
}
