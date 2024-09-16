using Core.Base.Dto;

namespace OrganizationService.Branch.ChangeMainBranch.Dto
{
    public class BranchChangeMainBranchDto : BaseDto
    {
        public Guid OrganizationId { get; set; }
        public Guid BranchId { get; set; }
    }
}
