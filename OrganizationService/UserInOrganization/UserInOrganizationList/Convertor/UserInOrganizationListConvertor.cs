using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationList.Dto;

namespace OrganizationService.UserInOrganization.UserInOrganizationList.Convertor
{
    public class UserInOrganizationListConvertor : IUserInOrganizationListConvertor
    {
        public Task<List<UserInOrganizationListDto>> ConvertToWebModel(List<UserInOrganizationDbo> list, List<string> culture)
        {
            List<UserInOrganizationListDto> data = [];
            foreach (UserInOrganizationDbo item in list)
            {
                UserInOrganizationListDto find = data.FirstOrDefault(x => x.Id == item.UserId);
                if (find == null)
                {
                    data.Add(
                        new UserInOrganizationListDto()
                        {
                            FirstName = item.User.Person.FirstName,
                            LastName = item.User.Person.LastName,
                            SecondName = item.User.Person.SecondName,
                            UserRole = [item.OrganizationRole.SystemIdentificator],
                            UserEmail = item.User.UserEmail,
                            Id = item.UserId,
                            UserInOrganizationId = item.Id
                        }
                    );
                }
                else
                {
                    find.UserRole.Add(item.OrganizationRole.SystemIdentificator);
                }
            }
            return Task.FromResult(data);
            /*return Task.FromResult(list
              .Select(item => new OrganizationRoleListDto() { RoleIndentificator = item.SystemIdentificator, RoleId = item.Id })
              .ToList());*/
        }
    }
}
