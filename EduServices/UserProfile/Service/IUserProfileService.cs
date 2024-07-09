using System;
using System.Collections.Generic;
using Core.Base.Service;
using Services.Organization.Dto;
using Services.StudentEvaluation.Dto;
using Services.User.Dto;
using Services.UserProfile.Dto;

namespace Services.UserProfile.Service
{
    public interface IUserProfileService : IBaseService
    {
        List<MyCertificateListDto> GetMyCertificate(Guid userId);
        List<MyCourseListDto> GetMyCourse(Guid userId, bool hideFinishCourse, string culture);
        List<MyTimeTableListDto> GetMyTimeTable(Guid userId, string culture);
        List<ManagedCourseListDto> GetManagedCourse(Guid userId);
        List<MyAttendanceListDto> GetMyAttendance(Guid userId, string culture);
        List<MyOrganizationListDto> GetMyOrganization(Guid userId);
        List<MyEvaluationListDto> GetMyEvaluation(Guid userId);
    }
}
