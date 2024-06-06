using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class BrachCountryNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_Branch_Cb_Country_CountryId", table: "Edu_Branch");

            migrationBuilder.DropForeignKey(name: "FK_Edu_OrganizationAddress_Cb_Country_CountryId", table: "Edu_OrganizationAddress");

            migrationBuilder.DropForeignKey(name: "FK_Edu_PersonAddress_Cb_Country_CountryId", table: "Edu_PersonAddress");

            migrationBuilder.AlterColumn<Guid>(name: "CountryId", table: "Edu_PersonAddress", type: "uniqueidentifier", nullable: true, oldClrType: typeof(Guid), oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(name: "CountryId", table: "Edu_OrganizationAddress", type: "uniqueidentifier", nullable: true, oldClrType: typeof(Guid), oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(name: "CountryId", table: "Edu_Branch", type: "uniqueidentifier", nullable: true, oldClrType: typeof(Guid), oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Branch_Cb_Country_CountryId",
                table: "Edu_Branch",
                column: "CountryId",
                principalTable: "Cb_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_OrganizationAddress_Cb_Country_CountryId",
                table: "Edu_OrganizationAddress",
                column: "CountryId",
                principalTable: "Cb_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_PersonAddress_Cb_Country_CountryId",
                table: "Edu_PersonAddress",
                column: "CountryId",
                principalTable: "Cb_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Edu_Branch_Cb_Country_CountryId", table: "Edu_Branch");

            migrationBuilder.DropForeignKey(name: "FK_Edu_OrganizationAddress_Cb_Country_CountryId", table: "Edu_OrganizationAddress");

            migrationBuilder.DropForeignKey(name: "FK_Edu_PersonAddress_Cb_Country_CountryId", table: "Edu_PersonAddress");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Edu_PersonAddress",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Edu_OrganizationAddress",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Edu_Branch",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Branch_Cb_Country_CountryId",
                table: "Edu_Branch",
                column: "CountryId",
                principalTable: "Cb_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_OrganizationAddress_Cb_Country_CountryId",
                table: "Edu_OrganizationAddress",
                column: "CountryId",
                principalTable: "Cb_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_PersonAddress_Cb_Country_CountryId",
                table: "Edu_PersonAddress",
                column: "CountryId",
                principalTable: "Cb_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
