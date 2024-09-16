using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class EmailType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cb_Email");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Edu_TestQuestionAnswer");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Edu_BankOfQuestion");

            migrationBuilder.CreateTable(
                name: "Cb_EmailType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_EmailType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Edu_Email",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsHtml = table.Column<bool>(type: "bit", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Email_Cb_EmailType_EmailTypeId",
                        column: x => x.EmailTypeId,
                        principalTable: "Cb_EmailType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Edu_Email_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cb_EmailTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailBodyHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailBodyPlainText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailDboId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_EmailTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cb_EmailTranslation_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cb_EmailTranslation_Edu_Email_EmailDboId",
                        column: x => x.EmailDboId,
                        principalTable: "Edu_Email",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cb_EmailTranslation_CultureId",
                table: "Cb_EmailTranslation",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_EmailTranslation_EmailDboId",
                table: "Cb_EmailTranslation",
                column: "EmailDboId");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_EmailTranslation_SystemIdentificator",
                table: "Cb_EmailTranslation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Email_EmailTypeId",
                table: "Edu_Email",
                column: "EmailTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Email_OrganizationId",
                table: "Edu_Email",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Email_SystemIdentificator",
                table: "Edu_Email",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cb_EmailTranslation");

            migrationBuilder.DropTable(
                name: "Edu_Email");

            migrationBuilder.DropTable(
                name: "Cb_EmailType");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Edu_TestQuestionAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Edu_BankOfQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cb_Email",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailBodyHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailBodyPlainText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHtml = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_Email", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cb_Email_SystemIdentificator",
                table: "Cb_Email",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
        }
    }
}
