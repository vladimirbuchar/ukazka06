using Core.Base.Convertor;
using Model.Edu.Branch;
using Services.Branch.Dto;

namespace Services.Branch.Convertor
{
    public interface IBranchConvertor : IBaseConvertor<BranchDbo, BranchCreateDto, BranchListDto, BranchDetailDto, BranchUpdateDto> { }
}
