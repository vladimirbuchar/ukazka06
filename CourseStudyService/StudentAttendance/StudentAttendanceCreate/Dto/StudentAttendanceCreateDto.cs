using Core.Base.Dto;

namespace CourseStudyService.StudentAttendance.StudentAttendanceCreate.Dto
{
    public class StudentAttendanceCreateDto : CreateDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseTermDateId { get; set; }
        public Guid CourseTermId { get; set; }
    }
}
