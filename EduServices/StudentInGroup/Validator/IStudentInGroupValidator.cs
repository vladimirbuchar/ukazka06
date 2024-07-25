using Core.Base.Validator;
using Model.Link;
using Repository.StudentInGroupRepository;
using Services.StudentInGroup.Dto;

namespace Services.StudentInGroup.Validator
{
    public interface IStudentInGroupValidator
        : IBaseValidatorCreate<StudentInGroupDbo, IStudentInGroupRepository, StudentInGroupCreateDto>
    { }
}
