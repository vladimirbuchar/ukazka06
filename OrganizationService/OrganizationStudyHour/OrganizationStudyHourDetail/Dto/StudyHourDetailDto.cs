using Core.Base.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourDetail.Dto
{
    public class StudyHourDetailDto : DetailDto
    {
        public string ActiveFrom { get; set; } = string.Empty;
        public string ActiveTo { get; set; } = string.Empty;
        public int Position { get; set; }
        public Guid ActiveFromId { get; set; }
        public Guid ActiveToId { get; set; }
    }
}
