using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.Lector.LectorCourseList.Convertor;
using CourseStudyService.Lector.LectorCourseList.Dto;
using Model.Link;
using Repository.CourseLector;

namespace CourseStudyService.Lector.LectorCourseList.Command
{
    public class LectorCourseListCommand : BaseListCommand<CourseLectorDbo, ICourseLectorRepository, LectorCourseListDto, ILectorCourseListConvertor, RequestFilter>, ILectorCourseListCommand
    {
        public LectorCourseListCommand(ICourseLectorRepository repository, ILectorCourseListConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
