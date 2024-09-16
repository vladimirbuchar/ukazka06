using Core.Base.Command.List;
using CourseService.CourseTerm.CourseTermList.Convertor;
using CourseService.CourseTerm.CourseTermList.Dto;
using CourseService.CourseTerm.CourseTermList.Filter;
using Model.Edu.ClassRoom;
using Model.Edu.CourseTerm;
using Repository.Course;
using Repository.CourseTerm;
using System.Linq.Expressions;

namespace CourseService.CourseTerm.CourseTermList.Command
{
    public class CourseTermListService
        : BaseListCommand<CourseTermDbo, ICourseTermRepository, CourseTermListDto, ICourseTermListConvertor, CourseTermFilter>,
            ICourseTermListService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseTermListService(ICourseRepository courseRepository, ICourseTermRepository repository, ICourseTermListConvertor convertor)
            : base(repository, convertor)
        {
            _courseRepository = courseRepository;
        }

        protected override Expression<Func<CourseTermDbo, bool>> PrepareSqlFilter(CourseTermFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CourseTermDbo), "courseTerm");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterBool(filter.Monday, parameter, expression, nameof(CourseTermDbo.Monday));
            expression = FilterBool(filter.Thursday, parameter, expression, nameof(CourseTermDbo.Thursday));
            expression = FilterBool(filter.Wednesday, parameter, expression, nameof(CourseTermDbo.Wednesday));
            expression = FilterBool(filter.Tuesday, parameter, expression, nameof(CourseTermDbo.Tuesday));
            expression = FilterBool(filter.Friday, parameter, expression, nameof(CourseTermDbo.Friday));
            expression = FilterBool(filter.Saturday, parameter, expression, nameof(CourseTermDbo.Saturday));
            expression = FilterBool(filter.Sunday, parameter, expression, nameof(CourseTermDbo.Sunday));
            expression = FilterGuid(filter.ClassRoomId, parameter, expression, nameof(CourseTermDbo.ClassRoomId));
            expression = FilterGuid(filter.BranchId, parameter, expression, nameof(CourseTermDbo.ClassRoom), nameof(ClassRoomDbo.BranchId));
            expression = FilterDate(
                filter.ActiveFrom.HasValue ? filter.ActiveFrom.Value : null,
                filter.ActiveTo.HasValue ? filter.ActiveTo.Value : DateTime.MaxValue,
                parameter,
                expression,
                nameof(CourseTermDbo.ActiveFrom),
                nameof(CourseTermDbo.ActiveTo)
            );
            return Expression.Lambda<Func<CourseTermDbo, bool>>(expression, parameter);
        }

        public override Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return _courseRepository.GetOrganizationId(objectId);
        }
    }
}
