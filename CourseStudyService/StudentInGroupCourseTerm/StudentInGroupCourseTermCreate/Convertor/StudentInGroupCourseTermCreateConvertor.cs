using CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Dto;
using Model.Link;

namespace CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Convertor
{
    public class StudentInGroupCourseTermCreateConvertor : IStudentInGroupCourseTermCreateConvertor
    {
        public Task<StudentInGroupCourseTermDbo> ConvertToBussinessEntity(StudentInGroupCourseTermCreateDto create, string culture)
        {
            return Task.FromResult(new StudentInGroupCourseTermDbo() { CourseTermId = create.CourseTermId, StudentGroupId = create.StudentGroupId });
        }
    }
}
