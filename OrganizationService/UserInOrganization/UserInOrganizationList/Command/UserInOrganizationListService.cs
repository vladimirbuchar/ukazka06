using Core.Base.Command.List;
using Core.Base.Sort;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationList.Convertor;
using OrganizationService.UserInOrganization.UserInOrganizationList.Dto;
using OrganizationService.UserInOrganization.UserInOrganizationList.Filter;
using OrganizationService.UserInOrganization.UserInOrganizationList.Sort;
using Repository.UserInOrganization;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace OrganizationService.UserInOrganization.UserInOrganizationList.Command
{
    public class UserInOrganizationListService
        : BaseListCommand<
            UserInOrganizationDbo,
            IUserInOrganizationRepository,
            UserInOrganizationListDto,
            IUserInOrganizationListConvertor,
            UserInOrganizationFilter
        >,
            IUserInOrganizationListService
    {
        public UserInOrganizationListService(IUserInOrganizationRepository repository, IUserInOrganizationListConvertor convertor)
            : base(repository, convertor) { }

        protected override Expression<Func<UserInOrganizationDbo, bool>> PrepareSqlFilter(UserInOrganizationFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(UserInOrganizationDbo), "userInOrganization");
            Expression expression = Expression.Constant(true);
            expression = FilterString(
                filter.FirstName,
                parameter,
                expression,
                nameof(UserInOrganizationDbo.User),
                nameof(UserInOrganizationDbo.User.Person),
                nameof(UserInOrganizationDbo.User.Person.FirstName)
            );
            expression = FilterString(
                filter.SecondName,
                parameter,
                expression,
                nameof(UserInOrganizationDbo.User),
                nameof(UserInOrganizationDbo.User.Person),
                nameof(UserInOrganizationDbo.User.Person.SecondName)
            );
            expression = FilterString(
                filter.LastName,
                parameter,
                expression,
                nameof(UserInOrganizationDbo.User),
                nameof(UserInOrganizationDbo.User.Person),
                nameof(UserInOrganizationDbo.User.Person.LastName)
            );
            expression = FilterString(
                filter.UserEmail,
                parameter,
                expression,
                nameof(UserInOrganizationDbo.User),
                nameof(UserInOrganizationDbo.User.UserEmail)
            );
            expression = FilterString(
                filter.UserRole,
                parameter,
                expression,
                nameof(UserInOrganizationDbo.OrganizationRole),
                nameof(UserInOrganizationDbo.OrganizationRole.SystemIdentificator)
            );
            return Expression.Lambda<Func<UserInOrganizationDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<UserInOrganizationDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            ParameterExpression parameter = Expression.Parameter(typeof(UserInOrganizationDbo), "x");
            MemberExpression property = Expression.Property(parameter, nameof(UserInOrganizationDbo.User));

            if (columnName == UserInOrganizationSort.FirstName.ToString())
            {
                MemberExpression property1 = Expression.Property(property, nameof(UserInOrganizationDbo.User.Person));
                MemberExpression property2 = Expression.Property(property1, nameof(UserInOrganizationDbo.User.Person.FirstName));
                Expression<Func<UserInOrganizationDbo, object>> lambda = Expression.Lambda<Func<UserInOrganizationDbo, object>>(
                    Expression.Convert(property2, typeof(object)),
                    parameter
                );
                return [new BaseSort<UserInOrganizationDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            if (columnName == UserInOrganizationSort.SecondName.ToString())
            {
                MemberExpression property1 = Expression.Property(property, nameof(UserInOrganizationDbo.User.Person));
                MemberExpression property2 = Expression.Property(property1, nameof(UserInOrganizationDbo.User.Person.SecondName));
                Expression<Func<UserInOrganizationDbo, object>> lambda = Expression.Lambda<Func<UserInOrganizationDbo, object>>(
                    Expression.Convert(property2, typeof(object)),
                    parameter
                );
                return [new BaseSort<UserInOrganizationDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            if (columnName == UserInOrganizationSort.LastName.ToString())
            {
                MemberExpression property1 = Expression.Property(property, nameof(UserInOrganizationDbo.User.Person));
                MemberExpression property2 = Expression.Property(property1, nameof(UserInOrganizationDbo.User.Person.LastName));
                Expression<Func<UserInOrganizationDbo, object>> lambda = Expression.Lambda<Func<UserInOrganizationDbo, object>>(
                    Expression.Convert(property2, typeof(object)),
                    parameter
                );
                return [new BaseSort<UserInOrganizationDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            if (columnName == UserInOrganizationSort.UserEmail.ToString())
            {
                MemberExpression property2 = Expression.Property(property, nameof(StudentInGroupDbo.UserInOrganization.User.UserEmail));
                Expression<Func<UserInOrganizationDbo, object>> lambda = Expression.Lambda<Func<UserInOrganizationDbo, object>>(
                    Expression.Convert(property2, typeof(object)),
                    parameter
                );
                return [new BaseSort<UserInOrganizationDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            if (columnName == UserInOrganizationSort.UserRole.ToString())
            {
                MemberExpression role = Expression.Property(parameter, nameof(UserInOrganizationDbo.OrganizationRole));
                MemberExpression roleName = Expression.Property(role, nameof(UserInOrganizationDbo.OrganizationRole.SystemIdentificator));
                Expression<Func<UserInOrganizationDbo, object>> lambda = Expression.Lambda<Func<UserInOrganizationDbo, object>>(
                    Expression.Convert(roleName, typeof(object)),
                    parameter
                );
                return [new BaseSort<UserInOrganizationDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
