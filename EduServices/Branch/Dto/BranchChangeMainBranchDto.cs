using System;
using Core.Base.Dto;

namespace Services.Branch.Dto
{
    public class BranchChangeMainBranchDto : BaseDto
    {
        public Guid OrganizationId { get; set; }
        public Guid BranchId { get; set; }
    }
}
