using Model.Link;
using UserService.UserProfile.MyOrganization.Dto;

namespace UserService.UserProfile.MyOrganization.Convertor
{
    public class MyOrganizationConvertor : IMyOrganizationConvertor
    {
        public Task<List<MyOrganizationListDto>> ConvertToWebModel(List<UserInOrganizationDbo> list, List<string> culture)
        {
            List<MyOrganizationListDto> data = [];
            foreach (UserInOrganizationDbo item in list)
            {
                MyOrganizationListDto find = data.FirstOrDefault(x => x.Id == item.Id);
                if (find == null)
                {
                    data.Add(
                        new MyOrganizationListDto()
                        {
                            Id = item.Organization.Id,
                            Name = item.Organization.Name,
                            OrganizationRole =
                            [
                                new()
                                {
                                    IsOrganizationOwner =
                                        item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER,
                                    IsCourseAdministrator =
                                        item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR,
                                    IsCourseEditor = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR,
                                    IsLector = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.LECTOR,
                                    IsOrganizationAdministrator =
                                        item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR,
                                    IsStudent = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT,
                                    UserInOrganizationRoleId = item.Id
                                }
                            ]
                        }
                    );
                }
                else
                {
                    find.OrganizationRole.Add(
                        new OrganizationRoleDto()
                        {
                            IsOrganizationOwner = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER,
                            IsCourseAdministrator = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR,
                            IsCourseEditor = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR,
                            IsLector = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.LECTOR,
                            IsOrganizationAdministrator =
                                item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR,
                            IsStudent = item.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.STUDENT,
                            UserInOrganizationRoleId = item.Id
                        }
                    );
                }
            }
            return Task.FromResult(data);
        }
    }
}
