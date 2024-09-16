using Core.Base.Command.Detail;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchDetail.Convertor;
using OrganizationService.Branch.BranchDetail.Dto;
using Repository.Branch;

namespace OrganizationService.Branch.BranchDetail.Command
{
    public class BranchDetailService : BaseDetailCommand<BranchDbo, IBranchRepository, BranchDetailDto, IBranchDetailConvertor>, IBranchDetailService
    {
        public BranchDetailService(IBranchRepository repository, IBranchDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
