using System;
using System.Collections.Generic;
using System.Linq;
using Model.Edu.OrganizationRole;
using Model.Link;
using Services.UserInOrganization.Dto;

namespace Services.UserInOrganization.Convertor
{
    public class UserInOrganizationConvertor : IUserInOrganizationConvertor
    {
        public UserInOrganizationConvertor() { }

        public List<UserInOrganizationListDto> ConvertToWebModel(List<UserInOrganizationDbo> getAllUserInOrganizations, string culture = "")
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
            return data;
        }

        public List<OrganizationRoleListDto> ConvertToWebModel(List<OrganizationRoleDbo> organizationRoles)
        {
            return organizationRoles
                .Select(item => new OrganizationRoleListDto() { RoleIndentificator = item.SystemIdentificator, RoleId = item.Id })
                .ToList();
        }

        public UserInOrganizationDbo ConvertToBussinessEntity(UserInOrganizationCreateDto create, string culture)
        {
            return new UserInOrganizationDbo() { };
        }

        public UserInOrganizationDetailDto ConvertToWebModel(UserInOrganizationDbo detail, string culture)
        {
            throw new NotImplementedException();
        }

        public UserInOrganizationDbo ConvertToBussinessEntity(UserInOrganizationUpdateDto update, UserInOrganizationDbo entity, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
