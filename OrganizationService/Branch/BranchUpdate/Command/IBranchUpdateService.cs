using Core.Base.Command.Update;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchUpdate.Dto;

namespace OrganizationService.Branch.BranchUpdate.Command
{
    public interface IBranchUpdateService : IBaseUpdateCommand<BranchDbo, BranchUpdateDto> { }
}
