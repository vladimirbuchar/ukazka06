using Core.Base.Validator;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterialRepository;
using Services.CourseMaterial.Dto;

namespace Services.CourseMaterial.Validator
{
    public interface ICourseMaterialValidator
        : IBaseValidator<CourseMaterialDbo, ICourseMaterialRepository, CourseMaterialCreateDto, CourseMaterialDetailDto, CourseMaterialUpdateDto> { }
}
