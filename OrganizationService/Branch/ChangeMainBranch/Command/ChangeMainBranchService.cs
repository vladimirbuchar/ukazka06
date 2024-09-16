using Core.Base.Command;
using Core.DataTypes;
using Model.Edu.Branch;
using OrganizationService.Branch.ChangeMainBranch.Dto;
using Repository.Branch;

namespace OrganizationService.Branch.ChangeMainBranch.Command
{
    public class ChangeMainBranchService : BaseCommand<IBranchRepository>, IChangeMainBranchService
    {
        public ChangeMainBranchService(IBranchRepository repository)
            : base(repository) { }

        public async Task<Result> Execute(BranchChangeMainBranchDto branchChangeMainBranchDto, Guid userId)
        {
            BranchDbo branch = await _repository.GetEntity(
                false,
                x => x.OrganizationId == branchChangeMainBranchDto.OrganizationId && x.IsMainBranch
            );
            if (branch != null)
            {
                branch.IsMainBranch = false;
                _ = await _repository.UpdateEntity(branch, userId);
            }
            branch = await _repository.GetEntity(
                false,
                x => x.Id == branchChangeMainBranchDto.BranchId && x.OrganizationId == branchChangeMainBranchDto.OrganizationId
            );
            if (branch != null)
            {
                branch.IsMainBranch = true;
                _ = await _repository.UpdateEntity(branch, userId);
            }
            return new Result();
        }
    }
}
