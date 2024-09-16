using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Link;
using Repository.UserInOrganization;
using UserService.UserProfile.ManagedCourse.Convertor;
using UserService.UserProfile.ManagedCourse.Dto;

namespace UserService.UserProfile.ManagedCourse.Command
{
    public class ManagedCourseService(IUserInOrganizationRepository repository, IManagedCourseConvertor convertor)
                : BaseListCommand<UserInOrganizationDbo, IUserInOrganizationRepository, ManagedCourseListDto, IManagedCourseConvertor, RequestFilter>(repository, convertor),
            IManagedCourseService
    {
    }
}
