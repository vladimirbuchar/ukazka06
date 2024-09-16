using Core.Base.Command.Update;
using CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Command
{
    public interface ICourseMaterialUpdateService : IBaseUpdateCommand<CourseMaterialDbo, CourseMaterialUpdateDto> { }
}
