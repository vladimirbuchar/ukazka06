using Core.Base.Convertor;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupCreate.Dto;

namespace OrganizationService.StudentGroup.StudentGroupCreate.Convertor
{
    public interface IStudentGroupCreateConvertor : IBaseCreateConvertor<StudentGroupDbo, StudentGroupCreateDto> { }
}
