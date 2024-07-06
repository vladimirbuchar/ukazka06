using Core.Base.Validator;
using EduRepository.CourseMaterialRepository;
using EduServices.CourseMaterial.Dto;
using Model.Edu.CourseMaterial;

namespace EduServices.CourseMaterial.Validator
{
    public interface ICourseMaterialValidator : IBaseValidator<CourseMaterialDbo, ICourseMaterialRepository, CourseMaterialCreateDto, CourseMaterialDetailDto, CourseMaterialUpdateDto> { }
}
