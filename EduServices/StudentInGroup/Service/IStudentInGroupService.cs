using Core.Base.Service;
using EduServices.StudentInGroup.Dto;
using Model.Link;

namespace EduServices.StudentInGroup.Service
{
    public interface IStudentInGroupService : IBaseService<StudentInGroupDbo, StudentInGroupCreateDto, StudentInGroupListDto, StudentInGroupDetailDto>
    {

    }
}
