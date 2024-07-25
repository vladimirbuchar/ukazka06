using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.Branch;
using Services.Branch.Dto;
using Services.Branch.Filter;
using System;
using System.Threading.Tasks;

namespace Services.Branch.Service
{
    public interface IBranchService : IBaseService<BranchDbo, BranchCreateDto, BranchListDto, BranchDetailDto, BranchUpdateDto, BranchFilter>
    {
        Task<Result> ChangeMainBranch(Guid organizationId, Guid newBranch, Guid userId);
    }
}
