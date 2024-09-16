using Core.Base.Command.Update;
using Core.Base.Repository.CodeBookRepository;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchUpdate.Convertor;
using OrganizationService.Branch.BranchUpdate.Dto;
using OrganizationService.Branch.BranchUpdate.Validator;
using Repository.Branch;

namespace OrganizationService.Branch.BranchUpdate.Command
{
    public class BranchUpdateService
        : BaseUpdateCommand<BranchDbo, IBranchRepository, BranchUpdateDto, IBranchUpdateConvertor, IBranchUpdateValidator>,
            IBranchUpdateService
    {
        public BranchUpdateService(
            IBranchRepository repository,
            IBranchUpdateConvertor convertor,
            IBranchUpdateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture) { }

        public override async Task<Result> Execute(BranchUpdateDto update, Guid userId, string culture, Result? result = null)
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
                BranchDbo mainBranch = await _repository.GetEntity(
                    false,
                    x => x.OrganizationId == organizationId && x.IsMainBranch && x.Id != update.Id
                );
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
                return await base.Execute(update, userId, culture, result);
            }
            return result;
        }

        protected override bool IsChanged(BranchDbo oldVersion, BranchUpdateDto newVersion, string culture)
        {
            return oldVersion.Name != newVersion.Name
                || oldVersion.BranchTranslations.FindTranslation([culture]).Description != newVersion.Description
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
    }
}
