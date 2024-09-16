using Core.Base.Validator;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupCreate.Dto;

namespace OrganizationService.StudentGroup.StudentGroupCreate.Validator
{
    public interface IStudentGroupCreateValidator : IBaseCreateValidator<StudentGroupDbo, StudentGroupCreateDto> { }
}
