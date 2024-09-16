using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFileContentFromDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Edu_ClassRoomTranslation");

            migrationBuilder.DropColumn(name: "FileContent", table: "Edu_QuestionFileRepository");

            migrationBuilder.DropColumn(name: "FileContent", table: "Edu_OrganizationFileRepository");

            migrationBuilder.DropColumn(name: "FileContent", table: "Edu_CourseMaterialileRepository");

            migrationBuilder.DropColumn(name: "FileContent", table: "Edu_CourseLessonItemFileRepository");

            migrationBuilder.DropColumn(name: "FileContent", table: "Edu_CourseLessonFileRepository");

            migrationBuilder.DropColumn(name: "FileContent", table: "Edu_AnswerFileRepository");

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Edu_QuestionFileRepository",
                type: "bigint",
                nullable: false,
                defaultValue: 0L
            );

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Edu_OrganizationFileRepository",
                type: "bigint",
                nullable: false,
                defaultValue: 0L
            );

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Edu_CourseMaterialileRepository",
                type: "bigint",
                nullable: false,
                defaultValue: 0L
            );

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Edu_CourseLessonItemFileRepository",
                type: "bigint",
                nullable: false,
                defaultValue: 0L
            );

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Edu_CourseLessonFileRepository",
                type: "bigint",
                nullable: false,
                defaultValue: 0L
            );

            migrationBuilder.AddColumn<long>(name: "FileSize", table: "Edu_AnswerFileRepository", type: "bigint", nullable: false, defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "FileSize", table: "Edu_QuestionFileRepository");

            migrationBuilder.DropColumn(name: "FileSize", table: "Edu_OrganizationFileRepository");

            migrationBuilder.DropColumn(name: "FileSize", table: "Edu_CourseMaterialileRepository");

            migrationBuilder.DropColumn(name: "FileSize", table: "Edu_CourseLessonItemFileRepository");

            migrationBuilder.DropColumn(name: "FileSize", table: "Edu_CourseLessonFileRepository");

            migrationBuilder.DropColumn(name: "FileSize", table: "Edu_AnswerFileRepository");

            migrationBuilder.AddColumn<byte[]>(name: "FileContent", table: "Edu_QuestionFileRepository", type: "varbinary(max)", nullable: true);

            migrationBuilder.AddColumn<byte[]>(name: "FileContent", table: "Edu_OrganizationFileRepository", type: "varbinary(max)", nullable: true);

            migrationBuilder.AddColumn<byte[]>(name: "FileContent", table: "Edu_CourseMaterialileRepository", type: "varbinary(max)", nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "Edu_CourseLessonItemFileRepository",
                type: "varbinary(max)",
                nullable: true
            );

            migrationBuilder.AddColumn<byte[]>(name: "FileContent", table: "Edu_CourseLessonFileRepository", type: "varbinary(max)", nullable: true);

            migrationBuilder.AddColumn<byte[]>(name: "FileContent", table: "Edu_AnswerFileRepository", type: "varbinary(max)", nullable: true);

            migrationBuilder.CreateTable(
                name: "Edu_ClassRoomTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_ClassRoomTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_ClassRoomTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_ClassRoomTranslation_Edu_ClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "Edu_ClassRoom",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_ClassRoomTranslation_ClassRoomId", table: "Edu_ClassRoomTranslation", column: "ClassRoomId");

            migrationBuilder.CreateIndex(name: "IX_Edu_ClassRoomTranslation_CultureId", table: "Edu_ClassRoomTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_ClassRoomTranslation_SystemIdentificator",
                table: "Edu_ClassRoomTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );
        }
    }
}
