using Core.Base.Command.Detail;
using CourseMaterialService.CourseMaterial.CourseMaterialDetail.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialDetail.Command
{
    public interface ICourseMaterialDetailService : IBaseDetailCommand<CourseMaterialDbo, CourseMaterialDetailDto> { }
}
