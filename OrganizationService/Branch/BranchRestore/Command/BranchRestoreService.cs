using Core.Base.Command.Restore;
using Model.Edu.Branch;
using Repository.Branch;

namespace OrganizationService.Branch.BranchRestore.Command
{
    public class BranchRestoreService : BaseRestoreCommand<BranchDbo, IBranchRepository>, IBranchRestoreService
    {
        public BranchRestoreService(IBranchRepository repository)
            : base(repository) { }
    }
}
