using Core.Base.Command;
using Core.DataTypes;
using OrganizationService.Branch.ChangeMainBranch.Dto;

namespace OrganizationService.Branch.ChangeMainBranch.Command
{
    public interface IChangeMainBranchService : IBaseCommand
    {
        Task<Result> Execute(BranchChangeMainBranchDto branchChangeMainBranchDto, Guid userId);
    }
}
