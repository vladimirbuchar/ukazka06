using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace CourseStudyService.CourseStudy.StartTest.Dto
{
    public class StartTestDto : CreateDto
    {
        [JsonIgnore]
        public Guid TestId { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
    }
}
