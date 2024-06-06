using Core.Base.Service;
using EduServices.StudentInGroup.Dto;
using Model.Tables.Link;

namespace EduServices.StudentInGroup.Service
{
    public interface IStudentInGroupService : IBaseService<StudentInGroupDbo, StudentInGroupCreateDto, StudentInGroupListDto, StudentInGroupDetailDto>
    {

    }
}
