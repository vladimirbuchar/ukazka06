using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.Lector.LectorList.Dto;
using Model.Link;

namespace CourseStudyService.Lector.LectorList.Command
{
    public interface ILectorListService : IBaseListCommand<CourseLectorDbo, LectorListDto, RequestFilter> { }
}
