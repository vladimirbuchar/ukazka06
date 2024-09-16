using Core.Base.Dto;

namespace OrganizationService.StudentGroup.StudentGroupCreate.Dto
{
    public class StudentGroupCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public string? Name { get; set; }
    }
}
