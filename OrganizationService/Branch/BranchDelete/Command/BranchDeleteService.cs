using Core.Base.Command.Delete;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.Branch;
using Repository.Branch;

namespace OrganizationService.Branch.BranchDelete.Command
{
    public class BranchDeleteService : BaseDeleteCommand<BranchDbo, IBranchRepository>, IBranchDeleteService
    {
        public BranchDeleteService(IBranchRepository repository)
            : base(repository) { }

        public override async Task<Result> Execute(Guid objectId, Guid userId)
        {
            BranchDbo branchDbo = await _repository.GetEntity(objectId);
            if (branchDbo != null && (branchDbo.IsMainBranch || branchDbo.IsOnline))
            {
                Result result = new();
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.BRANCH, MessageItem.CAN_NOT_DELETE));
                return result;
            }
            return await base.Execute(objectId, userId);
        }
    }
}
