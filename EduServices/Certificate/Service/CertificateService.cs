using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Service;
using Model.Edu.Certificate;
using Repository.CertificateRepository;
using Services.Certificate.Convertor;
using Services.Certificate.Dto;
using Services.Certificate.Filter;
using Services.Certificate.Validator;

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
            return Expression.Lambda<Func<CertificateDbo, bool>>(expression, parameter);
        }

        protected override List<CertificateDbo> PrepareMemoryFilter(List<CertificateDbo> entities, CertificateFilter filter, string culture)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                entities = entities
                    .Where(x => x.CertificateTranslations.Any(y => y.Name.Contains(filter.Name) && y.Culture.SystemIdentificator == culture))
                    .ToList();
            }
            return entities;
        }

        protected override bool IsChanged(CertificateDbo oldVersion, CertificateUpdateDto newVersion, string culture)
        {
            return oldVersion.CertificateValidTo != newVersion.CertificateValidTo
                || oldVersion.CertificateTranslations.FindTranslation(culture).Html != newVersion.Html
                || oldVersion.CertificateTranslations.FindTranslation(culture).Name != newVersion.Name;
        }
    }
}
