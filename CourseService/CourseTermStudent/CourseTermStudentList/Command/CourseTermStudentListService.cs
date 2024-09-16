using Core.Base.Command.List;
using Core.Base.Sort;
using CourseService.CourseTermStudent.CourseTermStudentList.Convertor;
using CourseService.CourseTermStudent.CourseTermStudentList.Dto;
using CourseService.CourseTermStudent.CourseTermStudentList.Filter;
using CourseService.CourseTermStudent.CourseTermStudentList.Sort;
using Model.Link;
using Repository.CourseStudent;
using Repository.CourseTerm;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace CourseService.CourseTermStudent.CourseTermStudentList.Command
{
    public class CourseTermStudentListService
        : BaseListCommand<
            CourseStudentDbo,
            ICourseStudentRepository,
            CourseTermStudentListDto,
            ICourseTermStudentListConvertor,
            CourseTermStudentFilter
        >,
            ICourseTermStudentListService
    {
        private readonly ICourseTermRepository _courseTermRepository;

        public CourseTermStudentListService(
            ICourseTermRepository courseTermRepository,
            ICourseStudentRepository repository,
            ICourseTermStudentListConvertor convertor
        )
            : base(repository, convertor)
        {
            _courseTermRepository = courseTermRepository;
        }

        public override Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return _courseTermRepository.GetOrganizationId(objectId);
        }

        protected override Expression<Func<CourseStudentDbo, bool>> PrepareSqlFilter(CourseTermStudentFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CourseStudentDbo), "courseStudent");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterBool(filter.CourseFinish, parameter, expression, nameof(CourseStudentDbo.CourseFinish));
            expression = FilterString(
                filter.FirstName,
                parameter,
                expression,
                nameof(CourseStudentDbo.UserInOrganization),
                nameof(CourseStudentDbo.UserInOrganization.User),
                nameof(CourseStudentDbo.UserInOrganization.User.Person),
                nameof(CourseStudentDbo.UserInOrganization.User.Person.FirstName)
            );
            expression = FilterString(
                filter.SecondName,
                parameter,
                expression,
                nameof(CourseStudentDbo.UserInOrganization),
                nameof(CourseStudentDbo.UserInOrganization.User),
                nameof(CourseStudentDbo.UserInOrganization.User.Person),
                nameof(CourseStudentDbo.UserInOrganization.User.Person.SecondName)
            );
            expression = FilterString(
                filter.LastName,
                parameter,
                expression,
                nameof(CourseStudentDbo.UserInOrganization),
                nameof(CourseStudentDbo.UserInOrganization.User),
                nameof(CourseStudentDbo.UserInOrganization.User.Person),
                nameof(CourseStudentDbo.UserInOrganization.User.Person.LastName)
            );
            expression = FilterString(
                filter.Email,
                parameter,
                expression,
                nameof(CourseStudentDbo.UserInOrganization),
                nameof(CourseStudentDbo.UserInOrganization.User),
                nameof(CourseStudentDbo.UserInOrganization.User.UserEmail)
            );

            return Expression.Lambda<Func<CourseStudentDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<CourseStudentDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CourseStudentDbo), "x");
            MemberExpression property = Expression.Property(parameter, nameof(CourseStudentDbo.UserInOrganization));
            MemberExpression property1 = Expression.Property(property, nameof(CourseStudentDbo.UserInOrganization.User));
            if (columnName == CourseTermStudentSort.FirstName.ToString())
            {
                MemberExpression property2 = Expression.Property(property1, nameof(CourseStudentDbo.UserInOrganization.User.Person));
                MemberExpression property3 = Expression.Property(property2, nameof(CourseStudentDbo.UserInOrganization.User.Person.FirstName));
                Expression<Func<CourseStudentDbo, object>> lambda = Expression.Lambda<Func<CourseStudentDbo, object>>(
                    Expression.Convert(property3, typeof(object)),
                    parameter
                );
                return [new BaseSort<CourseStudentDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            if (columnName == CourseTermStudentSort.SecondName.ToString())
            {
                MemberExpression property2 = Expression.Property(property1, nameof(CourseStudentDbo.UserInOrganization.User.Person));
                MemberExpression property3 = Expression.Property(property2, nameof(CourseStudentDbo.UserInOrganization.User.Person.SecondName));
                Expression<Func<CourseStudentDbo, object>> lambda = Expression.Lambda<Func<CourseStudentDbo, object>>(
                    Expression.Convert(property3, typeof(object)),
                    parameter
                );
                return [new BaseSort<CourseStudentDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            if (columnName == CourseTermStudentSort.LastName.ToString())
            {
                MemberExpression property2 = Expression.Property(property1, nameof(CourseStudentDbo.UserInOrganization.User.Person));
                MemberExpression property3 = Expression.Property(property2, nameof(CourseStudentDbo.UserInOrganization.User.Person.LastName));
                Expression<Func<CourseStudentDbo, object>> lambda = Expression.Lambda<Func<CourseStudentDbo, object>>(
                    Expression.Convert(property3, typeof(object)),
                    parameter
                );
                return [new BaseSort<CourseStudentDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            if (columnName == CourseTermStudentSort.Email.ToString())
            {
                MemberExpression property2 = Expression.Property(property1, nameof(CourseStudentDbo.UserInOrganization.User.UserEmail));
                Expression<Func<CourseStudentDbo, object>> lambda = Expression.Lambda<Func<CourseStudentDbo, object>>(
                    Expression.Convert(property2, typeof(object)),
                    parameter
                );
                return [new BaseSort<CourseStudentDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
