using Core.Base.Command.Create;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialCreate.Command
{
    public interface ICourseMaterialCreateService : IBaseCreateCommand<CourseMaterialDbo, CourseMaterialCreateDto> { }
}
