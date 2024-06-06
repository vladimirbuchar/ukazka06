using Core.Base.Service;
using Core.DataTypes;
using EduRepository.BranchRepository;
using EduServices.Branch.Convertor;
using EduServices.Branch.Dto;
using EduServices.Branch.Validator;
using Model.Tables.Edu.Branch;
using System;
using System.Collections.Generic;

namespace EduServices.Branch.Service
{
    public class BranchService(IBranchRepository repository, IBranchConvertor convertor, IBranchValidator validator)
        : BaseService<IBranchRepository, BranchDbo, IBranchConvertor, IBranchValidator, BranchCreateDto, BranchListDto, BranchDetailDto, BranchUpdateDto>(repository, convertor, validator),
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

        public override Result<BranchDetailDto> AddObject(BranchCreateDto addObject, Guid userId, string culture)
        {
            if (addObject.IsMainBranch)
            {
                BranchDbo mainBranch = _repository.GetEntity(false, x => x.OrganizationId == addObject.OrganizationId && x.IsMainBranch);
                if (mainBranch != null)
                {
                    mainBranch.IsMainBranch = false;
                    _ = _repository.UpdateEntity(mainBranch, userId);
                }
            }
            return base.AddObject(addObject, userId, culture);
        }

        public override Result<BranchDetailDto> UpdateObject(BranchUpdateDto update, Guid userId, string culture)
        {
            BranchDbo oldEntity = _repository.GetEntity(update.Id) ?? throw new KeyNotFoundException(update.Id.ToString());
            if (update.IsMainBranch)
            {
                Guid organizationId = _repository.GetOrganizationId(update.Id);
                BranchDbo mainBranch = _repository.GetEntity(false, x => x.OrganizationId == organizationId && x.IsMainBranch && x.Id != update.Id);
                if (mainBranch != null)
                {
                    mainBranch.IsMainBranch = false;
                    _ = _repository.UpdateEntity(mainBranch, userId);
                }
            }
            return base.UpdateObject(update, userId, culture);
        }

        public override void DeleteObject(Guid objectId, Guid userId)
        {
            BranchDbo branchDbo = _repository.GetEntity(objectId);
            if (branchDbo != null && (branchDbo.IsMainBranch || branchDbo.IsOnline))
            {
                return;
            }
            base.DeleteObject(objectId, userId);
        }

        public void ChangeMainBranch(Guid organizationId, Guid newBranchId, Guid userId)
        {
            BranchDbo branch = _repository.GetEntity(false, x => x.OrganizationId == organizationId && x.IsMainBranch);
            if (branch != null)
            {
                branch.IsMainBranch = false;
                _ = _repository.UpdateEntity(branch, userId);
            }
            branch = _repository.GetEntity(false, x => x.Id == newBranchId && x.OrganizationId == organizationId);
            if (branch != null)
            {
                branch.IsMainBranch = true;
                _ = _repository.UpdateEntity(branch, userId);
            }
        }
    }
}
