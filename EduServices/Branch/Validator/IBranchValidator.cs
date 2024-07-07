using Core.Base.Validator;
using Model.Edu.Branch;
using Repository.BranchRepository;
using Services.Branch.Dto;

namespace Services.Branch.Validator
{
    public interface IBranchValidator : IBaseValidator<BranchDbo, IBranchRepository, BranchCreateDto, BranchDetailDto, BranchUpdateDto> { }
}
