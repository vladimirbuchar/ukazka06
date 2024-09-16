using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace CourseMaterialService.CourseLesson.CourseLessonUpdatePosition.Dto
{
    public class CourseLessonUpdatePositionDto : UpdateDto
    {
        [JsonIgnore]
        public override Guid Id { get; set; }
        public required List<string> Ids { get; set; }
    }
}
