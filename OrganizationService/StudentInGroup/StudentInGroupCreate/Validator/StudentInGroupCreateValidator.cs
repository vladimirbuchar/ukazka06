using Core.Base.Validator;
using Model.Link;
using OrganizationService.StudentInGroup.StudentInGroupCreate.Dto;
using Repository.StudentInGroup;

namespace OrganizationService.StudentInGroup.StudentInGroupCreate.Validator
{
    public class StudentInGroupCreateValidator
        : BaseCreateValidator<StudentInGroupDbo, IStudentInGroupRepository, AddStudentToStudentGroup>,
            IStudentInGroupCreateValidator
    {
        public StudentInGroupCreateValidator(IStudentInGroupRepository repository)
            : base(repository) { }
    }
}
