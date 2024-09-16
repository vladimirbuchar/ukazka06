using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Dto
{
    public class StudyHourUpdateDto : UpdateDto
    {
        public Guid ActiveFromId { get; set; }
        public Guid ActiveToId { get; set; }
        public int Position { get; set; }

        [JsonIgnore]
        public Guid OrganizationId { get; set; }
    }
}
