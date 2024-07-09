using System;
using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.Branch;
using Services.Branch.Dto;
using Services.Branch.Filter;

namespace Services.Branch.Service
{
    public interface IBranchService : IBaseService<BranchDbo, BranchCreateDto, BranchListDto, BranchDetailDto, BranchUpdateDto, BranchFilter>
    {
        Result ChangeMainBranch(Guid organizationId, Guid newBranch, Guid userId);
    }
}
