using Core.Base.Dto;

namespace CourseStudyService.Student.StudentCourseDetail.Dto
{
    public class StudentCourseDetailDto : DetailDto
    {
        public bool CourseFinish { get; set; }
        public Guid UserInOrganizationId { get; set; }
        public Guid CourseTermId { get; set; }

    }
}
