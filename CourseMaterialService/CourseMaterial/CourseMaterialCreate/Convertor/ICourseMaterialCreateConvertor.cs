using Core.Base.Convertor;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialCreate.Convertor
{
    public interface ICourseMaterialCreateConvertor : IBaseCreateConvertor<CourseMaterialDbo, CourseMaterialCreateDto> { }
}
