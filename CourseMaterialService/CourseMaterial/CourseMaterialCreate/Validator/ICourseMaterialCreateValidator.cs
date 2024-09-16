using Core.Base.Validator;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialCreate.Validator
{
    public interface ICourseMaterialCreateValidator : IBaseCreateValidator<CourseMaterialDbo, CourseMaterialCreateDto> { }
}
