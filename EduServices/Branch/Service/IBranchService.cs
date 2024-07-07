﻿using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.Branch;
using Services.Branch.Dto;
using System;

namespace Services.Branch.Service
{
    public interface IBranchService : IBaseService<BranchDbo, BranchCreateDto, BranchListDto, BranchDetailDto, BranchUpdateDto>
    {
        Result ChangeMainBranch(Guid organizationId, Guid newBranch, Guid userId);
    }
}
