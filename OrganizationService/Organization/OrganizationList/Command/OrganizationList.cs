using Core.Base.Command.List;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationList.Convertor;
using OrganizationService.Organization.OrganizationList.Dto;
using OrganizationService.Organization.OrganizationList.Filter;
using Repository.Organization;
using System.Linq.Expressions;

namespace OrganizationService.Organization.OrganizationList.Command
{
    public class OrganizationList
        : BaseListCommand<OrganizationDbo, IOrganizationRepository, OrganizationListDto, IOrganizationListConvertor, OrganizationFilter>,
            IOrganizationList
    {
        public OrganizationList(IOrganizationRepository repository, IOrganizationListConvertor convertor)
            : base(repository, convertor) { }

        protected override Expression<Func<OrganizationDbo, bool>> PrepareSqlFilter(OrganizationFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(OrganizationDbo), "organization");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterString(filter.Name, parameter, expression, nameof(OrganizationDbo.Name));
            return Expression.Lambda<Func<OrganizationDbo, bool>>(expression, parameter);
        }
    }
}
