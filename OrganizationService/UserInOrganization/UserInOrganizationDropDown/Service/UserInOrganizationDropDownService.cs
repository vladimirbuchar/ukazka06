using Core.Base.Command.DropDown;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationDropDown.Convertor;
using OrganizationService.UserInOrganization.UserInOrganizationDropDown.Dto;
using Repository.UserInOrganization;

namespace OrganizationService.UserInOrganization.UserInOrganizationDropDown.Service
{
    public class UserInOrganizationDropDownService : BaseDropDownCommand<UserInOrganizationDbo, IUserInOrganizationRepository, UserInOrganizationDropDownDto, IUserInOrganizationDropDownConvertor>, IUserInOrganizationDropDownService
    {
        public UserInOrganizationDropDownService(IUserInOrganizationRepository repository, IUserInOrganizationDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
