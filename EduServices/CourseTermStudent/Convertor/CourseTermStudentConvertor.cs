using System.Collections.Generic;
using System.Linq;
using Model.Link;
using Services.CourseTermStudent.Dto;

namespace Services.CourseTermStudent.Convertor
{
    public class CourseTermStudentConvertor : ICourseTermStudentConvertor
    {
        public CourseStudentDbo ConvertToBussinessEntity(CourseTermStudentCreateDto create, string culture)
        {
            throw new System.NotImplementedException();
        }

        public HashSet<CourseTermStudentListDto> ConvertToWebModel(HashSet<CourseStudentDbo> list, string culture)
        {
            return list.Select(item => new CourseTermStudentListDto()
                {
                    FirstName = item.UserInOrganization.User.Person.FirstName,
                    Id = item.Id,
                    LastName = item.UserInOrganization.User.Person.LastName,
                    SecondName = item.UserInOrganization.User.Person.SecondName,
                    StudentId = item.UserInOrganizationId,
                    Email = item.UserInOrganization.User.UserEmail,
                    CourseFinish = item.CourseFinish
                })
                .ToHashSet();
        }

        public CourseTermStudentDetailDto ConvertToWebModel(CourseStudentDbo detail, string culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
