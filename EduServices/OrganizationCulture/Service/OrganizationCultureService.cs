using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Link;
using Repository.OrganizationCultureRepository;
using Services.OrganizationCulture.Convertor;
using Services.OrganizationCulture.Dto;
using Services.OrganizationCulture.Filter;
using Services.OrganizationCulture.Sort;
using Services.OrganizationCulture.Validator;
using System;
using System.Linq.Expressions;

namespace Services.OrganizationCulture.Service
{
    public class OrganizationCultureService(
        IOrganizationCultureRepository organizationRepository,
        IOrganizationCultureConvertor organizationSettingConvertor,
        IOrganizationCultureValidator validator
    )
        : BaseService<
            IOrganizationCultureRepository,
            OrganizationCultureDbo,
            IOrganizationCultureConvertor,
            IOrganizationCultureValidator,
            OrganizationCultureCreateDto,
            OrganizationCultureListDto,
            OrganizationCultureDetailDto,
            OrganizationCultureUpdateDto,
            OrganizationCultureFilter
        >(organizationRepository, organizationSettingConvertor, validator),
            IOrganizationCultureService
    {
        public override Result<OrganizationCultureDetailDto> AddObject(OrganizationCultureCreateDto addObject, Guid userId, string culture)
        {
            Result<OrganizationCultureDetailDto> result = _validator.IsValid(addObject);
            if (result.IsOk)
            {
                if (addObject.IsDefault == true)
                {
                    OrganizationCultureDbo organizationCultureDbo = _repository.GetEntity(
                        false,
                        x => x.OrganizationId == addObject.OrganizationId && x.IsDefault == true
                    );
                    organizationCultureDbo.IsDefault = false;
                    _ = _repository.UpdateEntity(organizationCultureDbo, userId);
                }
            }
            return base.AddObject(addObject, userId, culture);
        }

        public override Result DeleteObject(Guid objectId, Guid userId)
        {
            OrganizationCultureDbo organizationCulture = _repository.GetEntity(objectId);
            if (organizationCulture.IsDefault == true)
            {
                Result result = new();
                result.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION_CULTURE, Constants.CAN_NOT_DELETE_DEFAULT_CULTURE)
                );
                return result;
            }
            _repository.DeleteEntity(organizationCulture, userId);
            return new Result();
        }

        public override Result<OrganizationCultureDetailDto> UpdateObject(
            OrganizationCultureUpdateDto update,
            Guid userId,
            string culture,
            Result<OrganizationCultureDetailDto> result = null
        )
        {
            result = _validator.IsValid(update);
            if (result.IsOk)
            {
                if (update.IsDefault == true)
                {
                    OrganizationCultureDbo organizationCulture = _repository.GetEntity(
                        false,
                        x => x.OrganizationId == update.OrganizationId && x.IsDefault == true
                    );
                    organizationCulture.IsDefault = false;
                    _ = _repository.UpdateEntity(organizationCulture, userId);
                }
                return base.UpdateObject(update, userId, culture, result);
            }
            return result;
        }

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

        protected override bool IsChanged(OrganizationCultureDbo oldVersion, OrganizationCultureUpdateDto newVersion, string culture)
        {
            return oldVersion.IsDefault != newVersion.IsDefault;
        }

        protected override Expression<Func<OrganizationCultureDbo, object>> PrepareSort(string columnName, string culture)
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
                return lambda;
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
