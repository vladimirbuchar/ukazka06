using Core.Base.Command.Create;
using CourseStudyService.Lector.LectorCreate.Dto;
using Model.Link;

namespace CourseStudyService.Lector.LectorCreate.Command
{
    public interface ILectorCreateService : IBaseCreateCommand<CourseLectorDbo, LectorCreateDto> { }
}
