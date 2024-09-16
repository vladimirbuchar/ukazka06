using Core.Base.Command.List;
using Core.Base.Paging;
using Core.DataTypes;
using CourseService.CourseTermTimeTable.CourseTermTimeTableList.Convertor;
using CourseService.CourseTermTimeTable.CourseTermTimeTableList.Filter;
using Model.Edu.CourseTermDate;
using Repository.CourseTerm;
using Repository.CourseTermDate;
using Services.CourseTermTimeTable.CourseTermTimeTableList.Dto;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableList.Command
{
    public class CourseTermTimeTableListService
        : BaseListCommand<
            CourseTermDateDbo,
            ICourseTermDateRepository,
            CourseTermTimeTableListDto,
            ICourseTermTimeTableListConvertor,
            CourseTermTimeTableFilter
        >,
            ICourseTermTimeTableListService
    {
        private readonly ICourseTermRepository _courseTermRepository;

        public CourseTermTimeTableListService(
            ICourseTermRepository courseTermRepository,
            ICourseTermDateRepository repository,
            ICourseTermTimeTableListConvertor convertor
        )
            : base(repository, convertor)
        {
            _courseTermRepository = courseTermRepository;
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _courseTermRepository.GetOrganizationId(objectId);
        }

        protected override Expression<Func<CourseTermDateDbo, bool>> PrepareSqlFilter(CourseTermTimeTableFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CourseTermDateDbo), "courseTermDate");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterBool(filter.IsCanceled, parameter, expression, nameof(CourseTermDateDbo.IsCanceled));
            expression = FilterString(filter.DayOfWeek, parameter, expression, nameof(CourseTermDateDbo.DayOfWeek));
            expression = FilterDate(
                filter.Date.HasValue ? filter.Date.Value : null,
                filter.Date.HasValue ? filter.Date.Value : DateTime.MaxValue,
                parameter,
                expression,
                nameof(CourseTermDateDbo.Date),
                nameof(CourseTermDateDbo.Date)
            );
            expression = FilterString(
                filter.Lector,
                parameter,
                expression,
                nameof(CourseTermDateDbo.UserInOrganization),
                nameof(CourseTermDateDbo.UserInOrganization.User),
                nameof(CourseTermDateDbo.UserInOrganization.User.Person),
                nameof(CourseTermDateDbo.UserInOrganization.User.Person.FirstName)
            );
            expression = FilterString(
                filter.Lector,
                parameter,
                expression,
                nameof(CourseTermDateDbo.UserInOrganization),
                nameof(CourseTermDateDbo.UserInOrganization.User),
                nameof(CourseTermDateDbo.UserInOrganization.User.Person),
                nameof(CourseTermDateDbo.UserInOrganization.User.Person.SecondName)
            );
            expression = FilterString(
                filter.Lector,
                parameter,
                expression,
                nameof(CourseTermDateDbo.UserInOrganization),
                nameof(CourseTermDateDbo.UserInOrganization.User),
                nameof(CourseTermDateDbo.UserInOrganization.User.Person),
                nameof(CourseTermDateDbo.UserInOrganization.User.Person.LastName)
            );

            /*expression = FilterBool(filter.Thursday, parameter, expression, nameof(CourseTermDbo.Thursday));
            expression = FilterBool(filter.Wednesday, parameter, expression, nameof(CourseTermDbo.Wednesday));
            expression = FilterBool(filter.Tuesday, parameter, expression, nameof(CourseTermDbo.Tuesday));
            expression = FilterBool(filter.Friday, parameter, expression, nameof(CourseTermDbo.Friday));
            expression = FilterBool(filter.Saturday, parameter, expression, nameof(CourseTermDbo.Saturday));
            expression = FilterBool(filter.Sunday, parameter, expression, nameof(CourseTermDbo.Sunday));
            expression = FilterGuid(filter.ClassRoomId, parameter, expression, nameof(CourseTermDbo.ClassRoomId));
            expression = FilterGuid(filter.BranchId, parameter, expression, nameof(CourseTermDbo.ClassRoom), nameof(ClassRoomDbo.BranchId));
            expression = FilterDate(filter.ActiveFrom.HasValue ? filter.ActiveFrom.Value : null, filter.ActiveTo.HasValue ? filter.ActiveTo.Value : DateTime.MaxValue, parameter, expression, nameof(CourseTermDbo.ActiveFrom), nameof(CourseTermDbo.ActiveTo));*/
            return Expression.Lambda<Func<CourseTermDateDbo, bool>>(expression, parameter);
        }

        Task<ResultTable<CourseTermTimeTableListDto>> IBaseListCommand<CourseTermDateDbo, CourseTermTimeTableListDto, CourseTermTimeTableFilter>.Execute(Expression<Func<CourseTermDateDbo, bool>> predicate, bool deleted, List<string> culture, CourseTermTimeTableFilter filter, string sortColumn, SortDirection sortDirection, BasePaging paging)
        {
            throw new NotImplementedException();
        }

        Task<ResultTable<CourseTermTimeTableListDto>> IBaseListCommand<CourseTermDateDbo, CourseTermTimeTableListDto, CourseTermTimeTableFilter>.Execute()
        {
            throw new NotImplementedException();
        }

        Task<ResultTable<CourseTermTimeTableListDto>> IBaseListCommand<CourseTermDateDbo, CourseTermTimeTableListDto, CourseTermTimeTableFilter>.Execute(List<string> culture, CourseTermTimeTableFilter filter)
        {
            throw new NotImplementedException();
        }

        Task<ResultTable<CourseTermTimeTableListDto>> IBaseListCommand<CourseTermDateDbo, CourseTermTimeTableListDto, CourseTermTimeTableFilter>.Execute(bool deleted, List<string> culture)
        {
            throw new NotImplementedException();
        }
    }
}
