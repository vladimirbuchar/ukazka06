using Core.Base.Convertor;
using EduServices.Branch.Dto;
using Model.Tables.Edu.Branch;

namespace EduServices.Branch.Convertor
{
    public interface IBranchConvertor : IBaseConvertor<BranchDbo, BranchCreateDto, BranchListDto, BranchDetailDto, BranchUpdateDto> { }
}
