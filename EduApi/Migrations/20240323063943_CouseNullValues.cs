using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CouseNullValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_Course_Edu_Certificate_CertificateId", table: "Edu_Course");

            migrationBuilder.DropForeignKey(name: "FK_Edu_Course_Edu_SendMessage_SendMessageId", table: "Edu_Course");

            migrationBuilder.AlterColumn<Guid>(name: "SendMessageId", table: "Edu_Course", type: "uniqueidentifier", nullable: true, oldClrType: typeof(Guid), oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(name: "CourseMaterialId", table: "Edu_Course", type: "uniqueidentifier", nullable: true, oldClrType: typeof(Guid), oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(name: "CertificateId", table: "Edu_Course", type: "uniqueidentifier", nullable: true, oldClrType: typeof(Guid), oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Course_Edu_Certificate_CertificateId",
                table: "Edu_Course",
                column: "CertificateId",
                principalTable: "Edu_Certificate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Course_Edu_SendMessage_SendMessageId",
                table: "Edu_Course",
                column: "SendMessageId",
                principalTable: "Edu_SendMessage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_Course_Edu_Certificate_CertificateId", table: "Edu_Course");

            migrationBuilder.DropForeignKey(name: "FK_Edu_Course_Edu_SendMessage_SendMessageId", table: "Edu_Course");

            migrationBuilder.AlterColumn<Guid>(
                name: "SendMessageId",
                table: "Edu_Course",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseMaterialId",
                table: "Edu_Course",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AlterColumn<Guid>(
                name: "CertificateId",
                table: "Edu_Course",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Course_Edu_Certificate_CertificateId",
                table: "Edu_Course",
                column: "CertificateId",
                principalTable: "Edu_Certificate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Course_Edu_SendMessage_SendMessageId",
                table: "Edu_Course",
                column: "SendMessageId",
                principalTable: "Edu_SendMessage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
