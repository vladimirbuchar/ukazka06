using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupDetail.Dto;
using OrganizationService.StudentGroup.StudentGroupUpdate.Dto;
using Repository.StudentGroup;

namespace OrganizationService.StudentGroup.StudentGroupUpdate.Validator
{
    public class StudentGroupUpdateValidator
        : BaseUpdateValidator<StudentGroupDbo, IStudentGroupRepository, StudentGroupUpdateDto>,
            IStudentGroupUpdateValidator
    {
        public StudentGroupUpdateValidator(IStudentGroupRepository repository)
            : base(repository) { }

        public override async Task<Result> IsValid(StudentGroupUpdateDto update)
        {
            Result<StudentGroupDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.STUDENT_GROUP, MessageItem.STRING_IS_EMPTY);
            return await Task.FromResult(result);
        }
    }
}
