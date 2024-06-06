using Core.Base.Service;
using EduServices.Branch.Dto;
using Model.Tables.Edu.Branch;
using System;

namespace EduServices.Branch.Service
{
    public interface IBranchService : IBaseService<BranchDbo, BranchCreateDto, BranchListDto, BranchDetailDto, BranchUpdateDto>
    {
        void ChangeMainBranch(Guid organizationId, Guid newBranch, Guid userId);
    }
}
