using System.Collections.Generic;
using System.Linq;
using Model.Link;
using Services.StudentInGroup.Dto;

namespace Services.StudentInGroup.Convertor
{
    public class StudentInGroupConvertor : IStudentInGroupConvertor
    {
        public StudentInGroupConvertor() { }

        public StudentInGroupDbo ConvertToBussinessEntity(StudentInGroupCreateDto create, string culture)
        {
            return new StudentInGroupDbo() { };
        }

        public List<StudentInGroupListDto> ConvertToWebModel(List<StudentInGroupDbo> list, string culture)
        {
            return list.Select(x => new StudentInGroupListDto()
                {
                    Email = x.UserInOrganization.User.UserEmail,
                    FirstName = x.UserInOrganization.User.Person.FirstName,
                    Id = x.Id,
                    LastName = x.UserInOrganization.User.Person.LastName,
                    SecondName = x.UserInOrganization.User.Person.SecondName,
                    StudentId = x.UserInOrganizationId
                })
                .ToList();
        }

        public StudentInGroupDetailDto ConvertToWebModel(StudentInGroupDbo detail, string culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
