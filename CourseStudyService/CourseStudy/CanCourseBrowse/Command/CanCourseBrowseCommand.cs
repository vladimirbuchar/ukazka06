using Core.Base.Command;
using CourseStudyService.CourseStudy.CanCourseBrowse.Dto;
using Model.Link;
using Repository.Course;

namespace CourseStudyService.CourseStudy.CanCourseBrowse.Command
{
    public class CanCourseBrowseCommand : BaseCommand<ICourseRepository>, ICanCourseBrowseCommand
    {
        public CanCourseBrowseCommand(ICourseRepository repository) : base(repository)
        {

        }

        public async Task<UserOrganizationRoleDetailDto> Execute(Guid courseId, Guid userId)
        {
            UserInOrganizationDbo getAllUserInOrganizations = (await _repository.GetEntity(courseId)).Organization.UserInOrganizations.FirstOrDefault(x => x.UserId == userId && (
                        x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR
                        || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR
                        || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR
                        || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER
                    ));

            return new UserOrganizationRoleDetailDto()
            {
                IsCourseAdministrator = false,
                IsCourseEditor = false,
                IsOrganizationAdministrator = false,
                IsOrganizationOwner = false,
                IsLector = getAllUserInOrganizations?.CourseLectors?.FirstOrDefault(x => x.UserInOrganization.UserId == userId && x.Id == courseId && x.IsDeleted == false) != null,
                IsStudent = getAllUserInOrganizations?.CourseStudents?.FirstOrDefault(x => x.UserInOrganization.UserId == userId && x.CourseFinish == false && x.Id == courseId && x.IsDeleted == false) != null,
            };
        }
    }
}
