using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AnswerRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_TestQuestionAnswer_Edu_FileRepository_FileRepositoryId", table: "Edu_TestQuestionAnswer");

            migrationBuilder.DropTable(name: "Edu_FileRepository");

            migrationBuilder.DropIndex(name: "IX_Edu_TestQuestionAnswer_FileRepositoryId", table: "Edu_TestQuestionAnswer");

            migrationBuilder.DropColumn(name: "FileRepositoryId", table: "Edu_TestQuestionAnswer");

            migrationBuilder.DropColumn(name: "NotificationId", table: "Edu_Notification");

            migrationBuilder.CreateTable(
                name: "Edu_AnswerFileRepository",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_AnswerFileRepository", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_AnswerFileRepository_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_AnswerFileRepository_Edu_TestQuestionAnswer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Edu_TestQuestionAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_AnswerFileRepository_AnswerId", table: "Edu_AnswerFileRepository", column: "AnswerId");

            migrationBuilder.CreateIndex(name: "IX_Edu_AnswerFileRepository_CultureId", table: "Edu_AnswerFileRepository", column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_AnswerFileRepository_SystemIdentificator",
                table: "Edu_AnswerFileRepository",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Edu_AnswerFileRepository");

            migrationBuilder.AddColumn<Guid>(name: "FileRepositoryId", table: "Edu_TestQuestionAnswer", type: "uniqueidentifier", nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationId",
                table: "Edu_Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.CreateTable(
                name: "Edu_FileRepository",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    ObjectOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_FileRepository", x => x.Id);
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_TestQuestionAnswer_FileRepositoryId", table: "Edu_TestQuestionAnswer", column: "FileRepositoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_FileRepository_SystemIdentificator",
                table: "Edu_FileRepository",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_TestQuestionAnswer_Edu_FileRepository_FileRepositoryId",
                table: "Edu_TestQuestionAnswer",
                column: "FileRepositoryId",
                principalTable: "Edu_FileRepository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }
    }
}
