using Core.Base.Convertor;
using EduServices.Organization.Dto;
using EduServices.StudentEvaluation.Dto;
using EduServices.UserProfile.Dto;
using Model.Edu.StudentEvaluation;
using Model.Edu.UserCertificate;
using Model.Link;
using System.Collections.Generic;

namespace EduServices.UserProfile.Convertor
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
