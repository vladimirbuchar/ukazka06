using Core.Base.Service;
using Core.Base.Sort;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Branch;
using Repository.BranchRepository;
using Services.Branch.Convertor;
using Services.Branch.Dto;
using Services.Branch.Filter;
using Services.Branch.Sort;
using Services.Branch.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Services.Branch.Service
{

    public class BranchService(IBranchRepository repository, IBranchConvertor convertor, IBranchValidator validator)
        : BaseService<
            IBranchRepository,
            BranchDbo,
            IBranchConvertor,
            IBranchValidator,
            BranchCreateDto,
            BranchListDto,
            BranchDetailDto,
            BranchUpdateDto,
            BranchFilter
        >(repository, convertor, validator),
            IBranchService
    {
        protected override bool IsChanged(BranchDbo oldVersion, BranchUpdateDto newVersion, string culture)
        {
            return oldVersion.BranchTranslations.FindTranslation(culture).Name != newVersion.Name
                || oldVersion.BranchTranslations.FindTranslation(culture).Description != newVersion.Description
                || oldVersion.IsMainBranch != newVersion.IsMainBranch
                || oldVersion.Region != newVersion.Region
                || oldVersion.City != newVersion.City
                || oldVersion.Street != newVersion.Street
                || oldVersion.HouseNumber != newVersion.HouseNumber
                || oldVersion.ZipCode != newVersion.ZipCode
                || oldVersion.Email != newVersion.Email
                || oldVersion.PhoneNumber != newVersion.PhoneNumber
                || oldVersion.WWW != newVersion.WWW
                || oldVersion.CountryId != newVersion.CountryId;
        }

        public override async Task<Result> AddObject(BranchCreateDto addObject, Guid userId, string culture)
        {
            Result result = await _validator.IsValid(addObject);
            if (result.IsOk)
            {
                if (addObject.IsMainBranch)
                {
                    BranchDbo mainBranch = await _repository.GetEntity(false, x => x.OrganizationId == addObject.OrganizationId && x.IsMainBranch);
                    if (mainBranch != null)
                    {
                        mainBranch.IsMainBranch = false;
                        _ = await _repository.UpdateEntity(mainBranch, userId);
                    }
                }
                return await base.AddObject(addObject, userId, culture);
            }
            return result;
        }

        public override async Task<Result<BranchDetailDto>> UpdateObject(
            BranchUpdateDto update,
            Guid userId,
            string culture,
            Result<BranchDetailDto> result = null
        )
        {
            BranchDbo oldEntity = await _repository.GetEntity(update.Id) ?? throw new KeyNotFoundException(update.Id.ToString());
            if (oldEntity.IsOnline)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.BRANCH, MessageItem.CAN_NOT_EDIT));
                return result;
            }
            result = await _validator.IsValid(update);
            if (result.IsOk)
            {
                Guid organizationId = await _repository.GetOrganizationId(update.Id);
                BranchDbo mainBranch = await _repository.GetEntity(false, x => x.OrganizationId == organizationId && x.IsMainBranch && x.Id != update.Id);
                if (update.IsMainBranch)
                {
                    if (mainBranch != null)
                    {
                        mainBranch.IsMainBranch = false;
                        _ = await _repository.UpdateEntity(mainBranch, userId);
                    }
                }
                else
                {
                    if (mainBranch == null)
                    {
                        result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.BRANCH, Constants.MUST_SET_MAIN_BRANCH));
                    }
                }
                return await base.UpdateObject(update, userId, culture, result);
            }
            return result;
        }

        public override async Task<Result> DeleteObject(Guid objectId, Guid userId)
        {
            BranchDbo branchDbo = await _repository.GetEntity(objectId);
            if (branchDbo != null && (branchDbo.IsMainBranch || branchDbo.IsOnline))
            {
                Result result = new();
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.BRANCH, MessageItem.CAN_NOT_DELETE));
                return result;
            }
            return await base.DeleteObject(objectId, userId);
        }

        public async Task<Result> ChangeMainBranch(Guid organizationId, Guid newBranchId, Guid userId)
        {
            BranchDbo branch = await _repository.GetEntity(false, x => x.OrganizationId == organizationId && x.IsMainBranch);
            if (branch != null)
            {
                branch.IsMainBranch = false;
                _ = await _repository.UpdateEntity(branch, userId);
            }
            branch = await _repository.GetEntity(false, x => x.Id == newBranchId && x.OrganizationId == organizationId);
            if (branch != null)
            {
                branch.IsMainBranch = true;
                _ = await _repository.UpdateEntity(branch, userId);
            }
            return new Result();
        }

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
            expression = FilterTranslation<BranchTranslationDbo>(
                filter.Name,
                culture,
                parameter,
                expression,
                nameof(BranchTranslationDbo.Name),
                nameof(BranchTranslationDbo.Culture),
                nameof(BranchDbo.BranchTranslations)
            );
            expression = FilterGuid(filter.Country, parameter, expression, nameof(BranchDbo.CountryId));
            return Expression.Lambda<Func<BranchDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<BranchDbo>> PrepareSort(string columnName, string culture, SortDirection sortDirection = SortDirection.Ascending)
        {
            if (columnName == BranchSort.Name.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(BranchDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(BranchDbo.BranchTranslations));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(BranchTranslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(BranchTranslationDbo.Name));
                Expression<Func<BranchDbo, object>> lambda = Expression.Lambda<Func<BranchDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return
                [
                    new BaseSort<BranchDbo>()
                    {
                        Sort = lambda,
                        SortDirection = sortDirection
                    }
                ];
            }
            else if (columnName == BranchSort.Country.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(BranchDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(BranchDbo.Country));
                MemberExpression nameProperty = Expression.Property(property, nameof(CountryDbo.Name));
                Expression<Func<BranchDbo, object>> lambda = Expression.Lambda<Func<BranchDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return
                [
                    new BaseSort<BranchDbo>()
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
