using Core.Base.Convertor;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchUpdate.Dto;

namespace OrganizationService.Branch.BranchUpdate.Convertor
{
    public interface IBranchUpdateConvertor : IBaseUpdateConvertor<BranchDbo, BranchUpdateDto> { }
}
