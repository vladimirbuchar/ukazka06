using Core.Base.Validator;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchUpdate.Dto;

namespace OrganizationService.Branch.BranchUpdate.Validator
{
    public interface IBranchUpdateValidator : IBaseUpdateValidator<BranchDbo, BranchUpdateDto> { }
}
