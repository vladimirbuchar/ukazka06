using Core.Base.Validator;
using EduRepository.BranchRepository;
using EduServices.Branch.Dto;
using Model.Edu.Branch;

namespace EduServices.Branch.Validator
{
    public interface IBranchValidator : IBaseValidator<BranchDbo, IBranchRepository, BranchCreateDto, BranchDetailDto, BranchUpdateDto> { }
}
