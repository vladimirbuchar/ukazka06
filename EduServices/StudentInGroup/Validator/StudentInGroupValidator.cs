using Core.Base.Validator;
using EduRepository.StudentInGroupRepository;
using EduServices.StudentInGroup.Dto;
using Model.Tables.Link;

namespace EduServices.StudentInGroup.Validator
{
    public class StudentInGroupValidator(IStudentInGroupRepository repository)
        : BaseValidator<StudentInGroupDbo, IStudentInGroupRepository, StudentInGroupCreateDto, StudentInGroupDetailDto>(repository),
            IStudentInGroupValidator { }
}
