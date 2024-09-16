using Core.Base.Dto;

namespace CourseMaterialService.CourseMaterial.CourseMaterialCreate.Dto
{
    public class CourseMaterialCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
