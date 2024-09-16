using Core.Base.Command.List;
using Core.Base.Sort;
using Model.CodeBook;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchList.Convertor;
using OrganizationService.Branch.BranchList.Dto;
using OrganizationService.Branch.BranchList.Filter;
using OrganizationService.Branch.BranchList.Sort;
using Repository.Branch;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace OrganizationService.Branch.BranchList.Command
{
    public class BranchListService
        : BaseListCommand<BranchDbo, IBranchRepository, BranchListDto, IBranchListConvertor, BranchFilter>,
            IBranchListService
    {
        public BranchListService(IBranchRepository repository, IBranchListConvertor convertor)
            : base(repository, convertor) { }

        protected override Expression<Func<BranchDbo, bool>> PrepareSqlFilter(BranchFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(BranchDbo), "branch");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterBool(filter.IsMainBranch, parameter, expression, nameof(BranchDbo.IsMainBranch));
            expression = FilterString(filter.Region, parameter, expression, nameof(BranchDbo.Region));
            expression = FilterString(filter.City, parameter, expression, nameof(BranchDbo.City));
            expression = FilterString(filter.Street, parameter, expression, nameof(BranchDbo.Street));
            expression = FilterString(filter.HouseNumber, parameter, expression, nameof(BranchDbo.HouseNumber));
            expression = FilterString(filter.ZipCode, parameter, expression, nameof(BranchDbo.ZipCode));
            expression = FilterString(filter.Email, parameter, expression, nameof(BranchDbo.Email));
            expression = FilterString(filter.PhoneNumber, parameter, expression, nameof(BranchDbo.PhoneNumber));
            expression = FilterString(filter.WWW, parameter, expression, nameof(BranchDbo.WWW));
            expression = FilterString(filter.Name, parameter, expression, nameof(BranchDbo.Name));

            expression = FilterGuid(filter.Country, parameter, expression, nameof(BranchDbo.CountryId));
            return Expression.Lambda<Func<BranchDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<BranchDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            if (columnName == BranchSort.Country.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(BranchDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(BranchDbo.Country));
                MemberExpression nameProperty = Expression.Property(property, nameof(CountryDbo.Name));
                Expression<Func<BranchDbo, object>> lambda = Expression.Lambda<Func<BranchDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<BranchDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
