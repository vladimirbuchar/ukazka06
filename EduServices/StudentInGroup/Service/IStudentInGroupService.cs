using Core.Base.Service;
using Model.Link;
using Services.StudentInGroup.Dto;

namespace Services.StudentInGroup.Service
{
    public interface IStudentInGroupService : IBaseService<StudentInGroupDbo, StudentInGroupCreateDto, StudentInGroupListDto, StudentInGroupDetailDto>
    {

    }
}
