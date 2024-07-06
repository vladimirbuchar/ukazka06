using Core.Base.Validator;
using EduRepository.StudentInGroupRepository;
using EduServices.StudentInGroup.Dto;
using Model.Link;

namespace EduServices.StudentInGroup.Validator
{
    public interface IStudentInGroupValidator : IBaseValidator<StudentInGroupDbo, IStudentInGroupRepository, StudentInGroupCreateDto, StudentInGroupDetailDto> { }
}
