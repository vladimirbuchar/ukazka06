using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddSendEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_SendEmail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlainTextBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHtml = table.Column<bool>(type: "bit", nullable: false),
                    EmailFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailFromName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSended = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Edu_SendEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_SendEmail_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Edu_SendEmail_OrganizationId", table: "Edu_SendEmail", column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Edu_SendEmail");
        }
    }
}
