using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class StudentGroupName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Name", table: "Edu_BranchTranslation");

            migrationBuilder.AddColumn<string>(name: "Name", table: "Edu_StudentGroup", type: "nvarchar(max)", nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Name", table: "Edu_StudentGroup");

            migrationBuilder.AddColumn<string>(name: "Name", table: "Edu_BranchTranslation", type: "nvarchar(max)", nullable: true);
        }
    }
}
