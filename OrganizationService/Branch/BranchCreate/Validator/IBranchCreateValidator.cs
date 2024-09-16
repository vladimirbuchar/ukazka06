using Core.Base.Validator;
using Model.Edu.Branch;
using OrganizationService.Branch.BranchCreate.Dto;

namespace OrganizationService.Branch.BranchCreate.Validator
{
    public interface IBranchCreateValidator : IBaseCreateValidator<BranchDbo, BranchCreateDto> { }
}
