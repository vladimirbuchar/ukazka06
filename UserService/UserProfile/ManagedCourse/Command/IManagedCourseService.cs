using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Link;
using UserService.UserProfile.ManagedCourse.Dto;

namespace UserService.UserProfile.ManagedCourse.Command
{
    public interface IManagedCourseService : IBaseListCommand<UserInOrganizationDbo, ManagedCourseListDto, RequestFilter> { }
}
