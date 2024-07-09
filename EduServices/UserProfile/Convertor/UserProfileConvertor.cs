﻿using System.Collections.Generic;
using System.Linq;
using Core.Constants;
using Microsoft.Extensions.Configuration;
using Model.Edu.Branch;
using Model.Edu.ClassRoom;
using Model.Edu.StudentEvaluation;
using Model.Edu.UserCertificate;
using Model.Link;
using Services.Organization.Dto;
using Services.StudentEvaluation.Dto;
using Services.UserInOrganization.Dto;
using Services.UserProfile.Dto;

namespace Services.UserProfile.Convertor
{
    public class UserProfileConvertor(IConfiguration configuration) : IUserProfileConvertor
    {
        private readonly IConfiguration _configuration = configuration;

        public List<MyCertificateListDto> ConvertToWebModel(List<UserCertificateDbo> getMyCertificates)
        {
            return getMyCertificates
                .Select(x => new MyCertificateListDto()
                {
                    ActiveFrom = x.ActiveFrom,
                    Description = "",
                    FileName = string.Format(
                        "{0}{2}/{1}.pdf",
                        _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value,
                        x.FileName,
                        ConfigValue.CERTIFICATE_PATH
                    ),
                    Name = x.Name
                })
                .ToList();
        }

        public List<MyCourseListDto> ConvertToWebModel(List<CourseStudentDbo> getStudentCourses, string culture)
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
                .ToList();
        }

        public List<MyCourseListDto> ConvertToWebModel(List<CourseLectorDbo> getStudentCourses, string culture)
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
                .ToList();
        }

        public List<MyOrganizationListDto> ConvertToWebModel(List<UserInOrganizationDbo> getMyOrganizations)
        {
            List<MyOrganizationListDto> data = [];
            foreach (UserInOrganizationDbo item in getMyOrganizations)
            {
                MyOrganizationListDto find = data.FirstOrDefault(x => x.OrganizationId == item.Id);
                if (find == null)
                {
                    data.Add(
                        new MyOrganizationListDto()
                        {
                            OrganizationId = item.Organization.Id,
                            Name = item.Organization.Name,
                            OrganizationRole =
                            [
                                new()
                                {
                                    IsOrganizationOwner =
                                        item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER,
                                    IsCourseAdministrator =
                                        item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR,
                                    IsCourseEditor = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR,
                                    IsLector = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.LECTOR,
                                    IsOrganizationAdministrator =
                                        item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR,
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
                            IsOrganizationAdministrator =
                                item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR,
                            IsStudent = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT,
                            UserInOrganizationRoleId = item.Id
                        }
                    );
                }
            }
            return data;
        }

        public List<MyEvaluationListDto> ConvertToWebModel(List<StudentEvaluationDbo> getStudentEvaluation)
        {
            return getStudentEvaluation.Select(x => new MyEvaluationListDto() { }).ToList();
        }
    }
}
