using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.Lector.LectorList.Convertor;
using CourseStudyService.Lector.LectorList.Dto;
using Model.Link;
using Repository.CourseLector;

namespace CourseStudyService.Lector.LectorList.Command
{
    public class LectorListService
        : BaseListCommand<CourseLectorDbo, ICourseLectorRepository, LectorListDto, ILectorListConvertor, RequestFilter>,
            ILectorListService
    {
        public LectorListService(ICourseLectorRepository repository, ILectorListConvertor convertor)
            : base(repository, convertor) { }
    }
}
