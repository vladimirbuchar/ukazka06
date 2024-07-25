using Model.Link;
using Services.StudentInGroup.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.StudentInGroup.Convertor
{
    public class StudentInGroupConvertor : IStudentInGroupConvertor
    {
        public StudentInGroupConvertor() { }

        public Task<StudentInGroupDbo> ConvertToBussinessEntity(StudentInGroupCreateDto create, string culture)
        {
            return Task.FromResult(new StudentInGroupDbo() { });
        }

        public Task<List<StudentInGroupListDto>> ConvertToWebModel(List<StudentInGroupDbo> list, string culture)
        {
            return Task.FromResult(list.Select(x => new StudentInGroupListDto()
            {
                Email = x.UserInOrganization.User.UserEmail,
                FirstName = x.UserInOrganization.User.Person.FirstName,
                Id = x.Id,
                LastName = x.UserInOrganization.User.Person.LastName,
                SecondName = x.UserInOrganization.User.Person.SecondName,
                StudentId = x.UserInOrganizationId
            })
                .ToList());
        }

        public Task<StudentInGroupDetailDto> ConvertToWebModel(StudentInGroupDbo detail, string culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
