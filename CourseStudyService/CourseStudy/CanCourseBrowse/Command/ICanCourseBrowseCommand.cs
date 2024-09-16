using Core.Base.Command;
using CourseStudyService.CourseStudy.CanCourseBrowse.Dto;

namespace CourseStudyService.CourseStudy.CanCourseBrowse.Command
{
    public interface ICanCourseBrowseCommand : IBaseCommand
    {
        Task<UserOrganizationRoleDetailDto> Execute(Guid courseId, Guid userId);
    }
}