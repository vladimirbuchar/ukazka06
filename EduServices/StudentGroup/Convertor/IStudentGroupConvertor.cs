using Core.Base.Convertor;
using Model.Edu.StudentGroup;
using Services.StudentGroup.Dto;

namespace Services.StudentGroup.Convertor
{
    public interface IStudentGroupConvertor
        : IBaseConvertor<StudentGroupDbo, StudentGroupCreateDto, StudentGroupInOrganizationListDto, StudentGroupDetailDto, StudentGroupUpdateDto> { }
}
