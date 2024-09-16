using CourseStudyService.Student.StudentCourseDetail.Dto;
using Model.Link;

namespace CourseStudyService.Student.StudentCourseDetail.Convertor
{
    internal class StudentCourseDetailConvertor : IStudentCourseDetailConvertor
    {
        public Task<StudentCourseDetailDto> ConvertToWebModel(CourseStudentDbo detail, List<string> culture)
        {
            return Task.FromResult(new StudentCourseDetailDto()
            {
                CourseFinish = detail.CourseFinish,
                CourseTermId = detail.CourseTermId,
                Id = detail.Id,
                UserInOrganizationId = detail.UserInOrganizationId
            });
        }
    }
}
