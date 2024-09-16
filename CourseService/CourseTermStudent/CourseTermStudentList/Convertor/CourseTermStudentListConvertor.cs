using CourseService.CourseTermStudent.CourseTermStudentList.Dto;
using Model.Link;

namespace CourseService.CourseTermStudent.CourseTermStudentList.Convertor
{
    public class CourseTermStudentListConvertor : ICourseTermStudentListConvertor
    {
        public Task<List<CourseTermStudentListDto>> ConvertToWebModel(List<CourseStudentDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new CourseTermStudentListDto()
                {
                    FirstName = item.UserInOrganization.User.Person.FirstName,
                    Id = item.Id,
                    LastName = item.UserInOrganization.User.Person.LastName,
                    SecondName = item.UserInOrganization.User.Person.SecondName,
                    StudentId = item.UserInOrganizationId,
                    Email = item.UserInOrganization.User.UserEmail,
                    CourseFinish = item.CourseFinish
                })
                    .ToList()
            );
        }
    }
}
