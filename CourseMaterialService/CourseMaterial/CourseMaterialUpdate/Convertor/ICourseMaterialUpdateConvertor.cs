using Core.Base.Convertor;
using CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Convertor
{
    public interface ICourseMaterialUpdateConvertor : IBaseUpdateConvertor<CourseMaterialDbo, CourseMaterialUpdateDto> { }
}
