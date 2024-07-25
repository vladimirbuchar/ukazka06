using Core.Base.Service;
using Core.Base.Sort;
using Model.Edu.Branch;
using Model.Edu.Certificate;
using Repository.CertificateRepository;
using Services.Certificate.Convertor;
using Services.Certificate.Dto;
using Services.Certificate.Filter;
using Services.Certificate.Sort;
using Services.Certificate.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace Services.Certificate.Service
{
    public class CertificateService(
        ICertificateRepository certificateRepository,
        ICertificateConvertor certificateConvertor,
        ICertificateValidator validator
    )
        : BaseService<
            ICertificateRepository,
            CertificateDbo,
            ICertificateConvertor,
            ICertificateValidator,
            CertificateCreateDto,
            CertificateListDto,
            CertificateDetailDto,
            CertificateUpdateDto,
            CertificateFilter
        >(certificateRepository, certificateConvertor, validator),
            ICertificateService
    {
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

        protected override bool IsChanged(CertificateDbo oldVersion, CertificateUpdateDto newVersion, string culture)
        {
            return oldVersion.CertificateValidTo != newVersion.CertificateValidTo
                || oldVersion.CertificateTranslations.FindTranslation(culture).Html != newVersion.Html
                || oldVersion.CertificateTranslations.FindTranslation(culture).Name != newVersion.Name;
        }

        protected override List<BaseSort<CertificateDbo>> PrepareSort(string columnName, string culture, SortDirection sortDirection = SortDirection.Ascending)
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
                return
                [
                    new BaseSort<CertificateDbo>()
                    {
                        Sort =lambda,
                        SortDirection = sortDirection
                    }
                ];
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
