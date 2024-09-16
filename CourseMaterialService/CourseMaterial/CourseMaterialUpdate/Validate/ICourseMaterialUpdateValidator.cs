using Core.Base.Validator;
using CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Validate
{
    public interface ICourseMaterialUpdateValidator : IBaseUpdateValidator<CourseMaterialDbo, CourseMaterialUpdateDto> { }
}
