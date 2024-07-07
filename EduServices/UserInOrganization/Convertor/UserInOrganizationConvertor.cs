using Model.Edu.OrganizationRole;
using Model.Link;
using Services.UserInOrganization.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.UserInOrganization.Convertor
{
    public class UserInOrganizationConvertor : IUserInOrganizationConvertor
    {
        public UserInOrganizationConvertor() { }

        public HashSet<UserInOrganizationListDto> ConvertToWebModel(HashSet<UserInOrganizationDbo> getAllUserInOrganizations, string culture = "")
        {
            HashSet<UserInOrganizationListDto> data = [];
            foreach (UserInOrganizationDbo item in getAllUserInOrganizations)
            {
                UserInOrganizationListDto find = data.FirstOrDefault(x => x.Id == item.UserId);
                if (find == null)
                {
                    _ = data.Add(
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

        public HashSet<OrganizationRoleListDto> ConvertToWebModel(HashSet<OrganizationRoleDbo> organizationRoles)
        {
            return organizationRoles.Select(item => new OrganizationRoleListDto() { RoleIndentificator = item.SystemIdentificator, RoleId = item.Id }).ToHashSet();
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
