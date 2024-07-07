using System.Collections.Generic;
using Core.Base.Convertor;
using Model.Edu.StudentEvaluation;
using Model.Edu.UserCertificate;
using Model.Link;
using Services.Organization.Dto;
using Services.StudentEvaluation.Dto;
using Services.UserProfile.Dto;

namespace Services.UserProfile.Convertor
{
    public interface IUserProfileConvertor : IBaseConvertor
    {
        HashSet<MyCertificateListDto> ConvertToWebModel(HashSet<UserCertificateDbo> getMyCertificates);
        HashSet<MyCourseListDto> ConvertToWebModel(HashSet<CourseStudentDbo> getStudentCourses, string culture);
        HashSet<MyCourseListDto> ConvertToWebModel(HashSet<CourseLectorDbo> getStudentCourses, string culture);
        HashSet<MyOrganizationListDto> ConvertToWebModel(HashSet<UserInOrganizationDbo> getMyOrganizations);
        HashSet<MyEvaluationListDto> ConvertToWebModel(HashSet<StudentEvaluationDbo> getStudentEvaluation);
    }
}
