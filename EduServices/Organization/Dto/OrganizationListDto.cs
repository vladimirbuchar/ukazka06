using Core.Base.Dto;

namespace Services.Organization.Dto
{
    public class OrganizationListDto : ListDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}
