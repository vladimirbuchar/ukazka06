using Core.Base.Command.List;
using Core.Base.Filter;
using Core.Base.Paging;
using Core.Constants;
using Core.DataTypes;
using CourseStudyService.CourseStudy.CourseMenu.Convertor;
using CourseStudyService.CourseStudy.CourseMenu.Dto;
using Model.Edu.CourseLesson;
using Repository.CourseLesson;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace CourseStudyService.CourseStudy.CourseMenu.Command
{
    public class CourseMenuCommand : BaseListCommand<CourseLessonDbo, ICourseLessonRepository, CourseMenuItemDto, ICourseMenuConvertor, RequestFilter>, ICourseMenuCommand
    {
        public CourseMenuCommand(ICourseLessonRepository repository, ICourseMenuConvertor convertor) : base(repository, convertor)
        {

        }
        public override async Task<ResultTable<CourseMenuItemDto>> Execute(Expression<Func<CourseLessonDbo, bool>>? predicate = null, bool deleted = false, List<string>? culture = null, RequestFilter? filter = null, string sortColumn = "", SortDirection sortDirection = SortDirection.Ascending, BasePaging? paging = null)
        {
            List<CourseMenuItemDto> courseMenuItems = (await base.Execute(predicate, deleted, culture, filter, sortColumn, sortDirection, paging)).Data;
            courseMenuItems.Add(
               new CourseMenuItemDto()
               {
                   Id = Guid.Empty,
                   Items = [],
                   Name = CourseLessonType.LAST_SLIDE,
                   Type = CourseLessonType.LAST_SLIDE,
               }
           );
            return new ResultTable<CourseMenuItemDto>()
            {
                Data = courseMenuItems,
                TotalCount = courseMenuItems.Count
            };

        }
    }
}
