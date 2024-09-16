using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchCreate.Convertor;
using OrganizationService.Branch.BranchCreate.Dto;
using OrganizationService.Branch.BranchCreate.Validator;
using Repository.Branch;

namespace OrganizationService.Branch.BranchCreate.Command
{
    public class BranchCreateService
        : BaseCreateCommand<BranchDbo, IBranchRepository, BranchCreateDto, IBranchCreateConvertor, IBranchCreateValidator>,
            IBranchCreateService
    {
        public BranchCreateService(
            IBranchRepository repository,
            IBranchCreateConvertor convertor,
            IBranchCreateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture) { }

        public override async Task<ResultInsert> Execute(BranchCreateDto addObject, Guid userId, string culture)
        {
            ResultInsert result = await _validator.IsValid(addObject);
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
                return await base.Execute(addObject, userId, culture);
            }
            return result;
        }
    }
}
