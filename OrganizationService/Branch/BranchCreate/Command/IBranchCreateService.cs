using Core.Base.Command.Create;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchCreate.Dto;

namespace OrganizationService.Branch.BranchCreate.Command
{
    public interface IBranchCreateService : IBaseCreateCommand<BranchDbo, BranchCreateDto> { }
}
