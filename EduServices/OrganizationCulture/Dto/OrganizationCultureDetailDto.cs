using Core.Base.Dto;

namespace EduServices.OrganizationCulture.Dto
{
    public class OrganizationCultureDetailDto : DetailDto
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
