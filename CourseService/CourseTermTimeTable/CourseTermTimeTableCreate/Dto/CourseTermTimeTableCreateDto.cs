using Core.Base.Dto;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableCreate.Dto
{
    public class CourseTermTimeTableCreateDto : CreateDto
    {
        public DateTime? ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }
        public Guid TimeFromId { get; set; }
        public Guid TimeToId { get; set; }
        public List<bool> Days = [];
        public Guid CourseTermId;
        public List<Guid> LectorIds { get; set; } = [];
        public Guid ClassRoomId { get; set; }
    }
}
