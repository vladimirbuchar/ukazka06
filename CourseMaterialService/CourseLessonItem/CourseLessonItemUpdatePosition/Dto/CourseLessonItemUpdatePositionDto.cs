using Core.Base.Dto;
using System.Text.Json.Serialization;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemUpdatePosition.Dto
{
    public class CourseLessonItemUpdatePositionDto : UpdateDto
    {
        [JsonIgnore]
        public override Guid Id { get; set; }
        public required List<string> Ids { get; set; }
    }
}
