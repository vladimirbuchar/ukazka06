using Core.Base.Command.List;
using Core.Base.Sort;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateList.Convertor;
using OrganizationService.Certificate.CertificateList.Dto;
using OrganizationService.Certificate.CertificateList.Filter;
using OrganizationService.Certificate.CertificateList.Sort;
using Repository.Certificate;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace OrganizationService.Certificate.CertificateList.Command
{
    public class CertificateListService
        : BaseListCommand<CertificateDbo, ICertificateRepository, CertificateListDto, ICertificateListConvertor, CertificateFilter>,
            ICertificateListService
    {
        public CertificateListService(ICertificateRepository repository, ICertificateListConvertor convertor)
            : base(repository, convertor) { }

        protected override Expression<Func<CertificateDbo, bool>> PrepareSqlFilter(CertificateFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CertificateDbo), "certificate");
            Expression expression = Expression.Constant(true);
            expression = FilterInt(filter.CertificateValidTo, parameter, expression, nameof(CertificateDbo.CertificateValidTo));
            expression = FilterTranslation<CertificateTranslationDbo>(
                filter.Name,
                culture,
                parameter,
                expression,
                nameof(CertificateTranslationDbo.Name),
                nameof(CertificateTranslationDbo.Culture),
                nameof(CertificateDbo.CertificateTranslations)
            );
            return Expression.Lambda<Func<CertificateDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<CertificateDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            if (columnName == CertificateSort.Name.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(CertificateDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(CertificateDbo.CertificateTranslations));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(CertificateTranslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(CertificateTranslationDbo.Name));
                Expression<Func<CertificateDbo, object>> lambda = Expression.Lambda<Func<CertificateDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<CertificateDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
