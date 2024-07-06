using Core.Base.Service;
using Core.DataTypes;
using EduServices.Branch.Dto;
using Model.Edu.Branch;
using System;

namespace EduServices.Branch.Service
{
    public interface IBranchService : IBaseService<BranchDbo, BranchCreateDto, BranchListDto, BranchDetailDto, BranchUpdateDto>
    {
        Result ChangeMainBranch(Guid organizationId, Guid newBranch, Guid userId);
    }
}
