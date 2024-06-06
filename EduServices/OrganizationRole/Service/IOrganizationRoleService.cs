using Core.Base.Service;
using System;
using System.Collections.Generic;

namespace EduServices.OrganizationRole.Service
{
    public interface IOrganizationRoleService : IBaseService
    {
        bool CheckPermition(Guid userId, Guid organizationId, string route, List<string> roles);
        Guid GetOrganizationIdByBranch(Guid branchId);
        Guid GetOrganizationIdByClassRoom(Guid classRoomId);
        Guid GetOrganizationIdByCourseId(Guid courseId);
        Guid GetOrganizationIdByTermId(Guid termId);
        Guid GetOrganizationByUserInOrganization(Guid id);
        Guid GetOrganizationIdByBankOfQuestion(Guid bankOfQuestion);
        Guid GetOrganizationByCourseLesson(Guid courseLessonId);
        Guid GetOrganizationByCourseLessonItem(Guid courseLessonItemId);
        Guid GetOrganizationIdByQuestion(Guid questionId);
        Guid GetOrganizationByAnswer(Guid answerId);
        Guid GetOrganizationByOrganizationStudyHour(Guid id);
        Guid GetOrganizationByStudentId(Guid studentId);
        Guid GetOrganizationByCertificateId(Guid certificateId);
        Guid GetOrganizationBySendMessage(Guid sendMessageId);
        Guid GetOrganizationByStudentGroupId(Guid studentGroupId);
        Guid GetOrganizationByCourseMaterial(Guid courseMaterialId);
        Guid GetOrganizationByOrganizationCulture(Guid id);
    }
}
