using Core.Base.Service;
using Model.Link;
using Services.StudentInGroup.Dto;
using Services.StudentInGroup.Filter;

namespace Services.StudentInGroup.Service
{
    public interface IStudentInGroupService
        : IBaseService<StudentInGroupDbo, StudentInGroupCreateDto, StudentInGroupListDto, StudentInGroupDetailDto, StudentInGroupFilter> { }
}
