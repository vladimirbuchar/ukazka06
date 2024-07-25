using Model.Link;
using Services.CourseTermStudent.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.CourseTermStudent.Convertor
{
    public class CourseTermStudentConvertor : ICourseTermStudentConvertor
    {
        public Task<CourseStudentDbo> ConvertToBussinessEntity(CourseTermStudentCreateDto create, string culture)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CourseTermStudentListDto>> ConvertToWebModel(List<CourseStudentDbo> list, string culture)
        {
            return Task.FromResult(list.Select(item => new CourseTermStudentListDto()
            {
                FirstName = item.UserInOrganization.User.Person.FirstName,
                Id = item.Id,
                LastName = item.UserInOrganization.User.Person.LastName,
                SecondName = item.UserInOrganization.User.Person.SecondName,
                StudentId = item.UserInOrganizationId,
                Email = item.UserInOrganization.User.UserEmail,
                CourseFinish = item.CourseFinish
            })
                .ToList());
        }

        public Task<CourseTermStudentDetailDto> ConvertToWebModel(CourseStudentDbo detail, string culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
