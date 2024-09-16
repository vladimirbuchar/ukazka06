using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class StudentGroupNameDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Edu_StudentGroupTranslation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_StudentGroupTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Edu_StudentGroupTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_StudentGroupTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_StudentGroupTranslation_Edu_StudentGroup_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "Edu_StudentGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_StudentGroupTranslation_CultureId", table: "Edu_StudentGroupTranslation", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentGroupTranslation_StudentGroupId",
                table: "Edu_StudentGroupTranslation",
                column: "StudentGroupId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentGroupTranslation_SystemIdentificator",
                table: "Edu_StudentGroupTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );
        }
    }
}
