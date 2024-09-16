using Core.Base.Command.List;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchList.Dto;
using OrganizationService.Branch.BranchList.Filter;

namespace OrganizationService.Branch.BranchList.Command
{
    public interface IBranchListService : IBaseListCommand<BranchDbo, BranchListDto, BranchFilter> { }
}
