using Core.Base.Command.List;
using Core.Base.Sort;
using Model.CodeBook;
using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureList.Convertor;
using OrganizationService.OrganizationCulture.OrganizationCultureList.Dto;
using OrganizationService.OrganizationCulture.OrganizationCultureList.Filter;
using OrganizationService.OrganizationCulture.OrganizationCultureList.Sort;
using Repository.OrganizationCulture;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace OrganizationService.OrganizationCulture.OrganizationCultureList.Command
{
    public class OrganizationCultureListService
        : BaseListCommand<
            OrganizationCultureDbo,
            IOrganizationCultureRepository,
            OrganizationCultureListDto,
            IOrganizationCultureListConvertor,
            OrganizationCultureFilter
        >,
            IOrganizationCultureListService
    {
        public OrganizationCultureListService(IOrganizationCultureRepository repository, IOrganizationCultureListConvertor convertor)
            : base(repository, convertor) { }

        protected override Expression<Func<OrganizationCultureDbo, bool>> PrepareSqlFilter(OrganizationCultureFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(OrganizationCultureDbo), "OrganizationCulture");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterString(
                filter.Name,
                parameter,
                expression,
                nameof(OrganizationCultureDbo.Culture),
                nameof(OrganizationCultureDbo.Culture.Name)
            );
            expression = FilterBool(filter.IsDefault, parameter, expression, nameof(OrganizationCultureDbo.IsDefault));
            return Expression.Lambda<Func<OrganizationCultureDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<OrganizationCultureDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            if (columnName == OrganizationCultureSort.Name.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(OrganizationCultureDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(OrganizationCultureDbo.Culture));
                MemberExpression nameProperty = Expression.Property(property, nameof(CultureDbo.Name));
                Expression<Func<OrganizationCultureDbo, object>> lambda = Expression.Lambda<Func<OrganizationCultureDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<OrganizationCultureDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
