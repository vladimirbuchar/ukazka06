using Core.Base.Validator;
using Model.Link;
using OrganizationService.StudentInGroup.StudentInGroupCreate.Dto;

namespace OrganizationService.StudentInGroup.StudentInGroupCreate.Validator
{
    public interface IStudentInGroupCreateValidator : IBaseCreateValidator<StudentInGroupDbo, AddStudentToStudentGroup> { }
}
