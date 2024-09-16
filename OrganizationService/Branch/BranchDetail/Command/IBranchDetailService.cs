using Core.Base.Command.Detail;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchDetail.Dto;

namespace OrganizationService.Branch.BranchDetail.Command
{
    public interface IBranchDetailService : IBaseDetailCommand<BranchDbo, BranchDetailDto> { }
}
