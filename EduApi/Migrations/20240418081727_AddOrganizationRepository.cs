using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddOrganizationRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "IsChanged", table: "System_ObjectHistory");

            migrationBuilder.DropColumn(name: "IsChanged", table: "SendEmailAttachmentDbo");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Link_UserInOrganization");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Link_TestBankOfQuestion");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Link_StudentInGroupCourseTerm");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Link_StudentInGroup");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Link_OrganizationCulture");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Link_CouseStudentMaterial");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Link_CourseStudent");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Link_CourseLector");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Link_CourseBrowse");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_UserRole");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_UserCertificate");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_User");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_TestUserAnswer");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_TestQuestionTranslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_TestQuestionAnswerTanslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_TestQuestionAnswer");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_TestQuestion");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_StudentTestSummary");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_StudentGroupTranslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_StudentGroup");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_StudentEvaluation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_SendMessageTranslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_SendMessage");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_SendEmail");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_QuestionFileRepository");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_PersonAddress");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_Person");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_OrganizationTranslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_OrganizationStudyHour");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_OrganizationRolePermition");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_OrganizationRole");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_OrganizationAddress");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_Organization");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_Notification");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_Note");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_LinkLifeTime");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_LicenseChange");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_Chat");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CourseTranslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CourseTestEvaluation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CourseTest");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CourseTermDate");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CourseTerm");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CourseTable");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CourseMaterialTranslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CourseMaterial");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CourseLessonTranslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CourseLessonItemTranslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CourseLessonItem");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CourseLesson");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_Course");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_ClassRoomTranslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_ClassRoom");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_CertificateTranslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_Certificate");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_BranchTranslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_Branch");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_BankOfQuestionTranslation");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_BankOfQuestion");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_AttendanceStudent");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Edu_AnswerFileRepository");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_TimeTable");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_SendMessageType");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_QuestionMode");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_NotificationType");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_NoteType");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_License");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_GalleryItemType");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_Email");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_Culture");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_CourseType");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_CourseStatus");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_CourseLessonItemTemplate");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_Country");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_AnswerMode");

            migrationBuilder.DropColumn(name: "IsChanged", table: "Cb_AddressType");

            migrationBuilder.CreateTable(
                name: "Edu_OrganizationFileRepository",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Edu_OrganizationFileRepository", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationFileRepository_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationFileRepository_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationFileRepository_CultureId",
                table: "Edu_OrganizationFileRepository",
                column: "CultureId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationFileRepository_OrganizationId",
                table: "Edu_OrganizationFileRepository",
                column: "OrganizationId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationFileRepository_SystemIdentificator",
                table: "Edu_OrganizationFileRepository",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Edu_OrganizationFileRepository");

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "System_ObjectHistory", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "SendEmailAttachmentDbo", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Link_UserInOrganization", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Link_TestBankOfQuestion", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Link_StudentInGroupCourseTerm", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Link_StudentInGroup", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Link_OrganizationCulture", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Link_CouseStudentMaterial", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Link_CourseStudent", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Link_CourseLector", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Link_CourseBrowse", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_UserRole", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_UserCertificate", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_User", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_TestUserAnswer", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_TestQuestionTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_TestQuestionAnswerTanslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_TestQuestionAnswer", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_TestQuestion", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_StudentTestSummaryQuestion", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_StudentTestSummaryAnswer", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_StudentTestSummary", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_StudentGroupTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_StudentGroup", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_StudentEvaluation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_SendMessageTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_SendMessage", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_SendEmail", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_QuestionFileRepository", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_PersonAddress", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_Person", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_OrganizationTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_OrganizationStudyHour", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_OrganizationSetting", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_OrganizationRolePermition", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_OrganizationRole", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_OrganizationAddress", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_Organization", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_Notification", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_Note", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_LinkLifeTime", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_LicenseChange", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_Chat", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CourseTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CourseTestEvaluation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CourseTest", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CourseTermDate", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CourseTerm", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CourseTable", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CourseMaterialTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CourseMaterial", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CourseLessonTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CourseLessonItemTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CourseLessonItem", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CourseLesson", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_Course", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_ClassRoomTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_ClassRoom", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_CertificateTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_Certificate", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_BranchTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_Branch", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_BankOfQuestionTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_BankOfQuestion", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_AttendanceStudent", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Edu_AnswerFileRepository", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_TimeTable", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_SendMessageType", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_QuestionMode", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_NotificationType", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_NoteType", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_License", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_GalleryItemType", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_Email", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_Culture", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_CourseType", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_CourseStatus", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_CourseLessonItemTemplate", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_Country", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_AnswerMode", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsChanged", table: "Cb_AddressType", type: "bit", nullable: true);
        }
    }
}
