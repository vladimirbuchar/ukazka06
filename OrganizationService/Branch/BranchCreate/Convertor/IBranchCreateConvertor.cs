using Core.Base.Convertor;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchCreate.Dto;

namespace OrganizationService.Branch.BranchCreate.Convertor
{
    public interface IBranchCreateConvertor : IBaseCreateConvertor<BranchDbo, BranchCreateDto> { }
}
