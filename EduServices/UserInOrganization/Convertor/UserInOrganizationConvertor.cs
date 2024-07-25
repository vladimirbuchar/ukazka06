using Model.Edu.OrganizationRole;
using Model.Link;
using Services.UserInOrganization.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.UserInOrganization.Convertor
{
    public class UserInOrganizationConvertor : IUserInOrganizationConvertor
    {
        public UserInOrganizationConvertor() { }

        public Task<List<UserInOrganizationListDto>> ConvertToWebModel(List<UserInOrganizationDbo> getAllUserInOrganizations, string culture = "")
        {
            List<UserInOrganizationListDto> data = [];
            foreach (UserInOrganizationDbo item in getAllUserInOrganizations)
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
        }



        public Task<UserInOrganizationDbo> ConvertToBussinessEntity(UserInOrganizationCreateDto create, string culture)
        {
            return Task.FromResult(new UserInOrganizationDbo() { });
        }

        public Task<UserInOrganizationDetailDto> ConvertToWebModel(UserInOrganizationDbo detail, string culture)
        {
            throw new NotImplementedException();
        }


        public Task<List<OrganizationRoleListDto>> ConvertToWebModel(List<OrganizationRoleDbo> organizationRoles)
        {
            return Task.FromResult(organizationRoles
               .Select(item => new OrganizationRoleListDto() { RoleIndentificator = item.SystemIdentificator, RoleId = item.Id })
               .ToList());
        }

        public Task<UserInOrganizationDbo> ConvertToBussinessEntity(UserInOrganizationUpdateDto update, UserInOrganizationDbo entity, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
