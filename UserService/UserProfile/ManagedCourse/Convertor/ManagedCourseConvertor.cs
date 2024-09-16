using Model.Edu.Course;
using Model.Link;
using UserService.UserProfile.ManagedCourse.Dto;

namespace UserService.UserProfile.ManagedCourse.Convertor
{
    public class ManagedCourseConvertor : IManagedCourseConvertor
    {
        public Task<List<ManagedCourseListDto>> ConvertToWebModel(List<UserInOrganizationDbo> list, List<string> culture)
        {
            List<ManagedCourseListDto> data = [];

            foreach (UserInOrganizationDbo item in list)
            {
                List<CourseDbo> courses = item.Organization.Course.ToList();
                foreach (CourseDbo course in courses)
                {
                    data.Add(
                        new ManagedCourseListDto()
                        {
                            CourseName = course.CourseTranslations.FindTranslation(culture)?.Name,
                            Id = course.Id,
                            OrganizationId = item.Id,
                            IsCourseAdministrator = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR,
                            IsCourseEditor = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR,
                            IsOrganizationAdministrator =
                                item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR,
                            IsOrganizationOwner = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER
                        }
                    );
                }
            }
            return Task.FromResult(data);
        }
    }
}
