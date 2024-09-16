using Core.Base.Convertor;
using CourseMaterialService.CourseMaterial.CourseMaterialList.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialList.Convertor
{
    public interface ICourseMaterialListConvertor : IBaseListConvertor<CourseMaterialDbo, CourseMaterialListDto> { }
}
