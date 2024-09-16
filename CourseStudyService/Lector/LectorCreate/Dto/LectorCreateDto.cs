using Core.Base.Dto;

namespace CourseStudyService.Lector.LectorCreate.Dto
{
    public class LectorCreateDto : CreateDto
    {
        public Guid CourseTermId { get; set; }
        public Guid UserInOrganizationId { get; set; }
    }
}
