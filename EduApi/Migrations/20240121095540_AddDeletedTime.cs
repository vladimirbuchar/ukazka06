using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddDeletedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "System_ObjectHistory", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Link_UserInOrganization", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Link_TestBankOfQuestion", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Link_StudentInGroupCourseTerm", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Link_StudentInGroup", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Link_OrganizationCulture", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Link_CouseStudentMaterial", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Link_CourseStudent", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Link_CourseLector", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Link_CourseBrowse", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_UserRoleTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_UserRole", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_UserCertificate", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_User", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_TestUserAnswer", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_TestQuestionTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_TestQuestionAnswerTanslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_TestQuestionAnswer", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_TestQuestion", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_StudentTestSummaryQuestion", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_StudentTestSummaryAnswer", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_StudentTestSummary", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_StudentGroupTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_StudentGroup", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_StudentEvaluation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_SendMessageTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_SendMessage", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_PersonAddress", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_Person", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_OrganizationTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_OrganizationStudyHour", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_OrganizationSetting", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_OrganizationRoleTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_OrganizationRolePermition", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_OrganizationRole", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_OrganizationAddress", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_Organization", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_Notification", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_Note", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_LinkLifeTime", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_Chat", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_FileRepository", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_CourseTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_CourseTestEvaluation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_CourseTest", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_CourseTermDate", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_CourseTerm", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_CourseMaterialTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_CourseMaterial", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_CourseLessonTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_CourseLessonItemTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_CourseLessonItem", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_CourseLesson", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_Course", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_ClassRoomTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_ClassRoom", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_CertificateTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_Certificate", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_BranchTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_Branch", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_BankOfQuestionTranslation", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_BankOfQuestion", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Edu_AttendanceStudent", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_TimeTable", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_SendMessageType", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_QuestionMode", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_NotificationType", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_NoteType", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_License", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_GalleryItemType", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_Email", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_Culture", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_CourseType", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_CourseStatus", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_CourseLessonItemTemplate", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_Country", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_AnswerMode", type: "datetime2", nullable: true);

            migrationBuilder.AddColumn<DateTime>(name: "DeletedTime", table: "Cb_AddressType", type: "datetime2", nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DeletedTime", table: "System_ObjectHistory");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Link_UserInOrganization");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Link_TestBankOfQuestion");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Link_StudentInGroupCourseTerm");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Link_StudentInGroup");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Link_OrganizationCulture");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Link_CouseStudentMaterial");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Link_CourseStudent");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Link_CourseLector");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Link_CourseBrowse");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_UserRoleTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_UserRole");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_UserCertificate");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_User");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_TestUserAnswer");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_TestQuestionTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_TestQuestionAnswerTanslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_TestQuestionAnswer");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_TestQuestion");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_StudentTestSummary");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_StudentGroupTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_StudentGroup");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_StudentEvaluation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_SendMessageTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_SendMessage");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_PersonAddress");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_Person");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_OrganizationTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_OrganizationStudyHour");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_OrganizationRoleTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_OrganizationRolePermition");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_OrganizationRole");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_OrganizationAddress");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_Organization");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_Notification");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_Note");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_LinkLifeTime");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_Chat");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_FileRepository");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_CourseTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_CourseTestEvaluation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_CourseTest");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_CourseTermDate");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_CourseTerm");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_CourseMaterialTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_CourseMaterial");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_CourseLessonTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_CourseLessonItemTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_CourseLessonItem");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_CourseLesson");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_Course");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_ClassRoomTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_ClassRoom");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_CertificateTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_Certificate");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_BranchTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_Branch");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_BankOfQuestionTranslation");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_BankOfQuestion");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Edu_AttendanceStudent");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_TimeTable");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_SendMessageType");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_QuestionMode");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_NotificationType");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_NoteType");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_License");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_GalleryItemType");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_Email");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_Culture");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_CourseType");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_CourseStatus");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_CourseLessonItemTemplate");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_Country");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_AnswerMode");

            migrationBuilder.DropColumn(name: "DeletedTime", table: "Cb_AddressType");
        }
    }
}
