using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddSendEmailAddAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(name: "EmailTo", table: "Edu_SendEmail", type: "nvarchar(max)", nullable: true);

            migrationBuilder.AddColumn<string>(name: "EmailToName", table: "Edu_SendEmail", type: "nvarchar(max)", nullable: true);

            migrationBuilder.CreateTable(
                name: "SendEmailAttachmentDbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SendEmailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SendEmailAttachmentDbo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SendEmailAttachmentDbo_Edu_SendEmail_SendEmailId",
                        column: x => x.SendEmailId,
                        principalTable: "Edu_SendEmail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(name: "IX_SendEmailAttachmentDbo_SendEmailId", table: "SendEmailAttachmentDbo", column: "SendEmailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "SendEmailAttachmentDbo");

            migrationBuilder.DropColumn(name: "EmailTo", table: "Edu_SendEmail");

            migrationBuilder.DropColumn(name: "EmailToName", table: "Edu_SendEmail");
        }
    }
}
