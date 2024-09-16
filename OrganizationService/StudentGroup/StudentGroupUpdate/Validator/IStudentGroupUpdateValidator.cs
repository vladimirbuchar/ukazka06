using Core.Base.Validator;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupUpdate.Dto;

namespace OrganizationService.StudentGroup.StudentGroupUpdate.Validator
{
    public interface IStudentGroupUpdateValidator : IBaseUpdateValidator<StudentGroupDbo, StudentGroupUpdateDto> { }
}
