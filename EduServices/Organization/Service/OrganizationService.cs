﻿using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using Model.CodeBook;
using Model.Edu.Organization;
using Repository.OrganizationRepository;
using Services.Organization.Convertor;
using Services.Organization.Dto;
using Services.Organization.Filter;
using Services.Organization.Validator;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Organization.Service
{
    public class OrganizationService(
        IOrganizationRepository organizationRepository,
        IOrganizationConvertor organizationConvertor,
        IOrganizationValidator validator,
        IFileUploadRepository<OrganizationFileRepositoryDbo> fileRepositoryDbo,
        ICodeBookRepository<CultureDbo> culture
    )
        : BaseService<
            IOrganizationRepository,
            OrganizationDbo,
            IOrganizationConvertor,
            IOrganizationValidator,
            OrganizationCreateDto,
            OrganizationListDto,
            OrganizationDetailDto,
            OrganizationUpdateDto,
            OrganizationFileRepositoryDbo,
            OrganizationFilter
        >(organizationRepository, organizationConvertor, validator, fileRepositoryDbo, culture),
            IOrganizationService
    {
        public async Task<OrganizationDetailWebDto> GetOrganizationDetailWeb(Guid organizationId)
        {
            return _convertor.ConvertToWebModelWeb(await _repository.GetEntity(organizationId));
        }

        protected override bool IsChanged(OrganizationDbo oldVersion, OrganizationUpdateDto newVersion, string culture)
        {
            return oldVersion.Email != newVersion.Email
                || oldVersion.PhoneNumber != newVersion.PhoneNumber
                || oldVersion.WWW != newVersion.WWW
                || oldVersion.Name != newVersion.Name;
        }

        protected override Expression<Func<OrganizationDbo, bool>> PrepareSqlFilter(OrganizationFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(OrganizationDbo), "organization");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterString(filter.Name, parameter, expression, nameof(OrganizationDbo.Name));
            return Expression.Lambda<Func<OrganizationDbo, bool>>(expression, parameter);
        }
    }
}
