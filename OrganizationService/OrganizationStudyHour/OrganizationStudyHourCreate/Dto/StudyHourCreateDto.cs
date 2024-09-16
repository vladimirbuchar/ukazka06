using Core.Base.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Dto
{
    public class StudyHourCreateDto : CreateDto
    {
        public Guid OrganizationId { get; set; }
        public Guid ActiveFromId { get; set; }
        public Guid? ActiveToId { get; set; } = Guid.Empty;
        public int Position { get; set; }
        public int LessonLength { get; set; }
    }
}
