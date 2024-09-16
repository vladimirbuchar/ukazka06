using Core.Base.Convertor;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupUpdate.Dto;

namespace OrganizationService.StudentGroup.StudentGroupUpdate.Convertor
{
    public interface IStudentGroupUpdateConvertor : IBaseUpdateConvertor<StudentGroupDbo, StudentGroupUpdateDto> { }
}
