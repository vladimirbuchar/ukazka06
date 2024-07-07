using Core.Base.Service;
using Services.Organization.Dto;
using Services.StudentEvaluation.Dto;
using Services.User.Dto;
using Services.UserProfile.Dto;
using System;
using System.Collections.Generic;

namespace Services.UserProfile.Service
{
    public interface IUserProfileService : IBaseService
    {
        HashSet<MyCertificateListDto> GetMyCertificate(Guid userId);
        HashSet<MyCourseListDto> GetMyCourse(Guid userId, bool hideFinishCourse, string culture);
        List<MyTimeTableListDto> GetMyTimeTable(Guid userId, string culture);
        HashSet<ManagedCourseListDto> GetManagedCourse(Guid userId);
        HashSet<MyAttendanceListDto> GetMyAttendance(Guid userId, string culture);
        HashSet<MyOrganizationListDto> GetMyOrganization(Guid userId);
        HashSet<MyEvaluationListDto> GetMyEvaluation(Guid userId);
    }
}
