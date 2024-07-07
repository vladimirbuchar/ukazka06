using Core.Base.Validator;
using Model.Edu.StudentGroup;
using Repository.StudentGroupRepository;
using Services.StudentGroup.Dto;

namespace Services.StudentGroup.Validator
{
    public interface IStudentGroupValidator : IBaseValidator<StudentGroupDbo, IStudentGroupRepository, StudentGroupCreateDto, StudentGroupDetailDto, StudentGroupUpdateDto> { }
}
