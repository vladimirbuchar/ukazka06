using Model.Link;
using OrganizationService.StudentInGroup.StudentInGroupList.Dto;

namespace OrganizationService.StudentInGroup.StudentInGroupList.Convertor
{
    public class StudentInGroupListConvertor : IStudentInGroupListConvertor
    {
        public Task<List<StudentInGroupListDto>> ConvertToWebModel(List<StudentInGroupDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(x => new StudentInGroupListDto()
                {
                    Email = x.UserInOrganization.User.UserEmail,
                    FirstName = x.UserInOrganization.User.Person.FirstName,
                    Id = x.Id,
                    LastName = x.UserInOrganization.User.Person.LastName,
                    SecondName = x.UserInOrganization.User.Person.SecondName,
                    StudentId = x.UserInOrganizationId
                })
                    .ToList()
            );
        }
    }
}
