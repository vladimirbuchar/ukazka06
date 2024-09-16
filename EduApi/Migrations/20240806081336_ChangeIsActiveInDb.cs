using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIsActiveInDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "IsActive", table: "Routes");

            migrationBuilder.DropColumn(name: "IsActive", table: "Permissions");

            migrationBuilder.DropColumn(name: "IsActive", table: "Link_UserInOrganization");

            migrationBuilder.DropColumn(name: "IsActive", table: "Link_TestBankOfQuestion");

            migrationBuilder.DropColumn(name: "IsActive", table: "Link_StudentInGroupCourseTerm");

            migrationBuilder.DropColumn(name: "IsActive", table: "Link_StudentInGroup");

            migrationBuilder.DropColumn(name: "IsActive", table: "Link_OrganizationCulture");

            migrationBuilder.DropColumn(name: "IsActive", table: "Link_CouseStudentMaterial");

            migrationBuilder.DropColumn(name: "IsActive", table: "Link_CourseStudent");

            migrationBuilder.DropColumn(name: "IsActive", table: "Link_CourseLector");

            migrationBuilder.DropColumn(name: "IsActive", table: "Link_CourseBrowse");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_UserRole");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_UserCertificate");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_TestUserAnswer");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_TestQuestionTranslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_TestQuestionAnswerTanslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_TestQuestionAnswer");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_TestQuestion");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_StudentTestSummary");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_StudentGroupTranslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_StudentGroup");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_StudentEvaluation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_SendMessageTranslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_SendMessage");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_SendEmailAttachment");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_SendEmail");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_QuestionFileRepository");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_PersonAddress");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_Person");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_OrganizationTranslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_OrganizationStudyHour");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_OrganizationRolePermition");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_OrganizationRole");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_OrganizationFileRepository");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_OrganizationAddress");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_Organization");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_Notification");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_Note");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_LinkLifeTime");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_LicenseChange");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_Chat");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseTranslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseTestEvaluation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseTest");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseTermDate");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseTerm");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseTable");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseMaterialTranslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseMaterialileRepository");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseMaterial");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseLessonTranslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseLessonItemTranslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseLessonItemFileRepository");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseLessonItem");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseLessonFileRepository");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CourseLesson");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_Course");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_ClassRoomTranslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_ClassRoom");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_CertificateTranslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_Certificate");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_BranchTranslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_Branch");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_BankOfQuestionTranslation");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_BankOfQuestion");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_AttendanceStudent");

            migrationBuilder.DropColumn(name: "IsActive", table: "Edu_AnswerFileRepository");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_TimeTable");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_SendMessageType");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_QuestionMode");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_NotificationType");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_NoteType");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_License");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_GalleryItemType");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_Email");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_Culture");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_CourseType");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_CourseStatus");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_CourseLessonItemTemplate");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_Country");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_AnswerMode");

            migrationBuilder.DropColumn(name: "IsActive", table: "Cb_AddressType");

            migrationBuilder.AddColumn<bool>(name: "IsCanceled", table: "Edu_CourseTermDate", type: "bit", nullable: false, defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "IsCanceled", table: "Edu_CourseTermDate");

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Routes", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Permissions", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Link_UserInOrganization", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Link_TestBankOfQuestion", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Link_StudentInGroupCourseTerm", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Link_StudentInGroup", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Link_OrganizationCulture", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Link_CouseStudentMaterial", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Link_CourseStudent", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Link_CourseLector", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Link_CourseBrowse", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_UserRole", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_UserCertificate", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_TestUserAnswer", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_TestQuestionTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_TestQuestionAnswerTanslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_TestQuestionAnswer", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_TestQuestion", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_StudentTestSummaryQuestion", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_StudentTestSummaryAnswer", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_StudentTestSummary", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_StudentGroupTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_StudentGroup", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_StudentEvaluation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_SendMessageTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_SendMessage", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_SendEmailAttachment", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_SendEmail", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_QuestionFileRepository", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_PersonAddress", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_Person", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_OrganizationTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_OrganizationStudyHour", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_OrganizationSetting", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_OrganizationRolePermition", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_OrganizationRole", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_OrganizationFileRepository", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_OrganizationAddress", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_Organization", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_Notification", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_Note", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_LinkLifeTime", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_LicenseChange", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_Chat", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseTestEvaluation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseTest", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseTermDate", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseTerm", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseTable", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseMaterialTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseMaterialileRepository", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseMaterial", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseLessonTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseLessonItemTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseLessonItemFileRepository", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseLessonItem", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseLessonFileRepository", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CourseLesson", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_Course", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_ClassRoomTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_ClassRoom", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_CertificateTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_Certificate", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_BranchTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_Branch", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_BankOfQuestionTranslation", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_BankOfQuestion", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_AttendanceStudent", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Edu_AnswerFileRepository", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_TimeTable", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_SendMessageType", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_QuestionMode", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_NotificationType", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_NoteType", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_License", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_GalleryItemType", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_Email", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_Culture", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_CourseType", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_CourseStatus", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_CourseLessonItemTemplate", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_Country", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_AnswerMode", type: "bit", nullable: true);

            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "Cb_AddressType", type: "bit", nullable: true);
        }
    }
}
