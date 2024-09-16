using Core.Base.Command.List;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupList.Dto;
using OrganizationService.StudentGroup.StudentGroupList.Filter;

namespace OrganizationService.StudentGroup.StudentGroupList.Command
{
    public interface IStudentGroupListService : IBaseListCommand<StudentGroupDbo, StudentGroupListDto, StudentGroupFilter> { }
}
