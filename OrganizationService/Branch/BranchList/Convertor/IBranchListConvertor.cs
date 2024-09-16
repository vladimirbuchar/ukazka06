using Core.Base.Convertor;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchList.Dto;

namespace OrganizationService.Branch.BranchList.Convertor
{
    public interface IBranchListConvertor : IBaseListConvertor<BranchDbo, BranchListDto> { }
}
