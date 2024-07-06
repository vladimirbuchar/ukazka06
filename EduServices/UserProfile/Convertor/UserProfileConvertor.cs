using Core.Constants;
using EduServices.Organization.Dto;
using EduServices.StudentEvaluation.Dto;
using EduServices.UserInOrganization.Dto;
using EduServices.UserProfile.Dto;
using Microsoft.Extensions.Configuration;
using Model.Edu.Branch;
using Model.Edu.ClassRoom;
using Model.Edu.StudentEvaluation;
using Model.Edu.UserCertificate;
using Model.Link;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.UserProfile.Convertor
{
    public class UserProfileConvertor(IConfiguration configuration) : IUserProfileConvertor
    {
        private readonly IConfiguration _configuration = configuration;

        public HashSet<MyCertificateListDto> ConvertToWebModel(HashSet<UserCertificateDbo> getMyCertificates)
        {
            return getMyCertificates
                .Select(x => new MyCertificateListDto()
                {
                    ActiveFrom = x.ActiveFrom,
                    Description = "",
                    FileName = string.Format("{0}{2}/{1}.pdf", _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value, x.FileName, ConfigValue.CERTIFICATE_PATH),
                    Name = x.Name
                })
                .ToHashSet();
        }

        public HashSet<MyCourseListDto> ConvertToWebModel(HashSet<CourseStudentDbo> getStudentCourses, string culture)
        {
            return getStudentCourses
                .Select(item => new MyCourseListDto()
                {
                    ActiveFrom = item.CourseTerm.ActiveFrom.Value,
                    ActiveTo = item.CourseTerm.ActiveTo.Value,
                    BranchName = item.CourseTerm.ClassRoom.Branch.BranchTranslations.FindTranslation(culture).Name,
                    CourseName = item.CourseTerm.ClassRoom.ClassRoomTranslations.FindTranslation(culture).Name,
                    Friday = item.CourseTerm.Friday,
                    Id = item.Id,
                    Monday = item.CourseTerm.Monday,
                    Saturday = item.CourseTerm.Saturday,
                    Sunday = item.CourseTerm.Sunday,
                    Thursday = item.CourseTerm.Thursday,
                    TimeFrom = item.CourseTerm.TimeFrom.Value,
                    TimeTo = item.CourseTerm.TimeTo.Value,
                    Tuesday = item.CourseTerm.Tuesday,
                    UserId = item.UserInOrganizationId,
                    Wednesday = item.CourseTerm.Wednesday,
                    OrganizationName = item.CourseTerm.ClassRoom.Branch.Organization.Name,
                    CourseFinish = item.CourseFinish,
                    CourseTermId = item.CourseTermId
                })
                .ToHashSet();
        }

        public HashSet<MyCourseListDto> ConvertToWebModel(HashSet<CourseLectorDbo> getStudentCourses, string culture)
        {
            return getStudentCourses
                .Select(item => new MyCourseListDto()
                {
                    ActiveFrom = item.CourseTerm.ActiveFrom.Value,
                    ActiveTo = item.CourseTerm.ActiveTo.Value,
                    BranchName = item.CourseTerm.ClassRoom.Branch.BranchTranslations.FindTranslation(culture).Name,
                    CourseName = item.CourseTerm.ClassRoom.ClassRoomTranslations.FindTranslation(culture).Name,
                    Friday = item.CourseTerm.Friday,
                    Id = item.Id,
                    Monday = item.CourseTerm.Monday,
                    Saturday = item.CourseTerm.Saturday,
                    Sunday = item.CourseTerm.Sunday,
                    Thursday = item.CourseTerm.Thursday,
                    TimeFrom = item.CourseTerm.TimeFrom.Value,
                    TimeTo = item.CourseTerm.TimeTo.Value,
                    Tuesday = item.CourseTerm.Tuesday,
                    UserId = item.UserInOrganizationId,
                    Wednesday = item.CourseTerm.Wednesday,
                    OrganizationName = item.CourseTerm.ClassRoom.Branch.Organization.Name,
                    CourseTermId = item.CourseTermId
                })
                .ToHashSet();
        }

        public HashSet<MyOrganizationListDto> ConvertToWebModel(HashSet<UserInOrganizationDbo> getMyOrganizations)
        {
            HashSet<MyOrganizationListDto> data = [];
            foreach (UserInOrganizationDbo item in getMyOrganizations)
            {
                MyOrganizationListDto find = data.FirstOrDefault(x => x.OrganizationId == item.Id);
                if (find == null)
                {
                    _ = data.Add(
                        new MyOrganizationListDto()
                        {
                            OrganizationId = item.Organization.Id,
                            Name = item.Organization.Name,
                            OrganizationRole =
                            [
                                new()
                                {
                                    IsOrganizationOwner = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER,
                                    IsCourseAdministrator = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR,
                                    IsCourseEditor = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR,
                                    IsLector = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.LECTOR,
                                    IsOrganizationAdministrator = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR,
                                    IsStudent = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT,
                                    UserInOrganizationRoleId = item.Id
                                }
                            ]
                        }
                    );
                }
                else
                {
                    find.OrganizationRole.Add(
                        new OrganizationRoleDto()
                        {
                            IsOrganizationOwner = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER,
                            IsCourseAdministrator = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR,
                            IsCourseEditor = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR,
                            IsLector = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.LECTOR,
                            IsOrganizationAdministrator = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR,
                            IsStudent = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT,
                            UserInOrganizationRoleId = item.Id
                        }
                    );
                }
            }
            return data;
        }

        public HashSet<MyEvaluationListDto> ConvertToWebModel(HashSet<StudentEvaluationDbo> getStudentEvaluation)
        {
            return getStudentEvaluation.Select(x => new MyEvaluationListDto()
            {

            }).ToHashSet();
        }
    }
}
