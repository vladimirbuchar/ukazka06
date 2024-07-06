using Core.Base.Convertor;
using EduServices.StudentInGroup.Dto;
using Model.Link;

namespace EduServices.StudentInGroup.Convertor
{
    public interface IStudentInGroupConvertor : IBaseConvertor<StudentInGroupDbo, StudentInGroupCreateDto, StudentInGroupListDto, StudentInGroupDetailDto> { }
}
