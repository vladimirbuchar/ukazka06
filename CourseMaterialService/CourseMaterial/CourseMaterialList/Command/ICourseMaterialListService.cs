using Core.Base.Command.List;
using CourseMaterialService.CourseMaterial.CourseMaterialList.Dto;
using CourseMaterialService.CourseMaterial.CourseMaterialList.Filter;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialList.Command
{
    public interface ICourseMaterialListService : IBaseListCommand<CourseMaterialDbo, CourseMaterialListDto, CourseMaterialFilter> { }
}
