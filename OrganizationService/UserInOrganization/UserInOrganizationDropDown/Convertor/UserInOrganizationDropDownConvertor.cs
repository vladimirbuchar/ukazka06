using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationDropDown.Dto;

namespace OrganizationService.UserInOrganization.UserInOrganizationDropDown.Convertor
{
    public class UserInOrganizationDropDownConvertor : IUserInOrganizationDropDownConvertor
    {
        public Task<List<UserInOrganizationDropDownDto>> ConvertToWebModel(List<UserInOrganizationDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new UserInOrganizationDropDownDto()
            {
                Id = x.Id,
                Name = string.Format("{0} {1} {2}", x.User.Person.FirstName, x.User.Person.SecondName, x.User.Person.LastName)
            }).ToList());
        }
    }
}
