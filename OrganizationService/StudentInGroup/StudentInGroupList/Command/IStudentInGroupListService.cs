using Core.Base.Command.List;
using Model.Link;
using OrganizationService.StudentInGroup.StudentInGroupList.Dto;
using OrganizationService.StudentInGroup.StudentInGroupList.Filter;

namespace OrganizationService.StudentInGroup.StudentInGroupList.Command
{
    public interface IStudentInGroupListService : IBaseListCommand<StudentInGroupDbo, StudentInGroupListDto, StudentInGroupFilter> { }
}
