using Core.Base.Dto;

namespace CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Dto
{
    public class StudentInGroupCourseTermCreateDto : CreateDto
    {
        public Guid CourseTermId;
        public Guid StudentGroupId;
    }
}
