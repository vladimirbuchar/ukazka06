using System.Collections.Generic;
using Core.Base.Convertor;
using EduServices.Organization.Dto;
using EduServices.UserProfile.Dto;
using Model.Tables.Edu.UserCertificate;
using Model.Tables.Link;

namespace EduServices.UserProfile.Convertor
{
    public interface IUserProfileConvertor : IBaseConvertor
    {
        HashSet<MyCertificateListDto> ConvertToWebModel(HashSet<UserCertificateDbo> getMyCertificates);
        HashSet<MyCourseListDto> ConvertToWebModel(HashSet<CourseStudentDbo> getStudentCourses, string culture);
        HashSet<MyCourseListDto> ConvertToWebModel(HashSet<CourseLectorDbo> getStudentCourses, string culture);
        HashSet<MyOrganizationListDto> ConvertToWebModel(HashSet<UserInOrganizationDbo> getMyOrganizations);
    }
}
