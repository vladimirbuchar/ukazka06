using Core.Base.Service;
using Core.Base.Sort;
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
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Helpers;

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
        public override async Task<Result> AddObject(OrganizationCultureCreateDto addObject, Guid userId, string culture)
        {
            Result result = await _validator.IsValid(addObject);
            if (result.IsOk)
            {
                if (addObject.IsDefault == true)
                {
                    OrganizationCultureDbo organizationCultureDbo = await _repository.GetEntity(
                        false,
                        x => x.OrganizationId == addObject.OrganizationId && x.IsDefault == true
                    );
                    organizationCultureDbo.IsDefault = false;
                    _ = await _repository.UpdateEntity(organizationCultureDbo, userId);
                }
            }
            return await base.AddObject(addObject, userId, culture);
        }

        public override async Task<Result> DeleteObject(Guid objectId, Guid userId)
        {
            OrganizationCultureDbo organizationCulture = await _repository.GetEntity(objectId);
            if (organizationCulture.IsDefault == true)
            {
                Result result = new();
                result.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION_CULTURE, Constants.CAN_NOT_DELETE_DEFAULT_CULTURE)
                );
                return await Task.FromResult(result);
            }
            await _repository.DeleteEntity(organizationCulture, userId);
            return await Task.FromResult(new Result());
        }

        public override async Task<Result<OrganizationCultureDetailDto>> UpdateObject(
            OrganizationCultureUpdateDto update,
            Guid userId,
            string culture,
            Result<OrganizationCultureDetailDto> result = null
        )
        {
            result = await _validator.IsValid(update);
            if (result.IsOk)
            {
                OrganizationCultureDbo organizationCulture = await _repository.GetEntity(
                        false,
                        x => x.OrganizationId == update.OrganizationId && x.IsDefault == true
                    );
                if (update.IsDefault == true)
                {
                    if (organizationCulture != null)
                    {
                        organizationCulture.IsDefault = false;
                        _ = await _repository.UpdateEntity(organizationCulture, userId);
                    }
                }
                else if (update.IsDefault == false)
                {
                    if (organizationCulture.IsDefault)
                    {
                        result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION_CULTURE, MessageItem.CAN_NOT_EDIT));
                    }
                }

                return await base.UpdateObject(update, userId, culture, result);
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

        protected override List<BaseSort<OrganizationCultureDbo>> PrepareSort(string columnName, string culture, SortDirection sortDirection = SortDirection.Ascending)
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
                return
                [
                   new BaseSort<OrganizationCultureDbo>()
                   {
                       Sort = lambda,
                       SortDirection = sortDirection
                   }
                ];
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
