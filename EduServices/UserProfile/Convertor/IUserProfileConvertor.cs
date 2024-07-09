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
        List<MyCertificateListDto> ConvertToWebModel(List<UserCertificateDbo> getMyCertificates);
        List<MyCourseListDto> ConvertToWebModel(List<CourseStudentDbo> getStudentCourses, string culture);
        List<MyCourseListDto> ConvertToWebModel(List<CourseLectorDbo> getStudentCourses, string culture);
        List<MyOrganizationListDto> ConvertToWebModel(List<UserInOrganizationDbo> getMyOrganizations);
        List<MyEvaluationListDto> ConvertToWebModel(List<StudentEvaluationDbo> getStudentEvaluation);
    }
}
