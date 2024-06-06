using System;
using System.Collections.Generic;
using Core.Base.Service;
using EduServices.Organization.Dto;
using EduServices.User.Dto;
using EduServices.UserProfile.Dto;

namespace EduServices.UserProfile.Service
{
    public interface IUserProfileService : IBaseService
    {
        HashSet<MyCertificateListDto> GetMyCertificate(Guid userId);
        HashSet<MyCourseListDto> GetMyCourse(Guid userId, bool hideFinishCourse, string culture);
        List<MyTimeTableListDto> GetMyTimeTable(Guid userId, string culture);
        HashSet<ManagedCourseListDto> GetManagedCourse(Guid userId);
        HashSet<MyAttendanceListDto> GetMyAttendance(Guid userId, string culture);
        HashSet<MyOrganizationListDto> GetMyOrganization(Guid userId);
    }
}
