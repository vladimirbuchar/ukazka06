using Core.Base.Convertor;
using Model.Link;
using UserService.UserProfile.ManagedCourse.Dto;

namespace UserService.UserProfile.ManagedCourse.Convertor
{
    public interface IManagedCourseConvertor : IBaseListConvertor<UserInOrganizationDbo, ManagedCourseListDto> { }
}
