using Core.Base.Validator;
using Model.Link;
using Repository.StudentInGroupRepository;
using Services.StudentInGroup.Dto;

namespace Services.StudentInGroup.Validator
{
    public class StudentInGroupValidator(IStudentInGroupRepository repository)
        : BaseValidator<StudentInGroupDbo, IStudentInGroupRepository, StudentInGroupCreateDto, StudentInGroupDetailDto>(repository),
            IStudentInGroupValidator { }
}
