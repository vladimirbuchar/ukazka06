using Core.Base.Convertor;
using Model.Link;
using Services.StudentInGroup.Dto;

namespace Services.StudentInGroup.Convertor
{
    public interface IStudentInGroupConvertor
        : IBaseConvertor<StudentInGroupDbo, StudentInGroupCreateDto, StudentInGroupListDto, StudentInGroupDetailDto> { }
}
