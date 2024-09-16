using CourseService.CourseTermStudent.CourseTermStudentCreate.Dto;
using Model.Link;

namespace CourseService.CourseTermStudent.CourseTermStudentCreate.Convertor
{
    public class CourseTermStudentCreateConvertor : ICourseTermStudentCreateConvertor
    {
        public Task<CourseStudentDbo> ConvertToBussinessEntity(AddCourseTermStudentDto create, string culture)
        {
            return Task.FromResult(new CourseStudentDbo() { CourseTermId = create.CourseTermId, UserInOrganizationId = create.UserInOrganizationId });
        }
    }
}
