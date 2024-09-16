using Core.Base.Command.Detail;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationDetail.Dto;
using Repository.UserInOrganization;
using System.Linq.Expressions;

namespace OrganizationService.UserInOrganization.UserInOrganizationDetail.Command
{
    public class UserInOrganizationDetailService
        : BaseDetailCommand<UserInOrganizationDbo, IUserInOrganizationRepository, UserInOrganizationDetailDto>,
            IUserInOrganizationDetailService
    {
        public UserInOrganizationDetailService(IUserInOrganizationRepository repository)
            : base(repository) { }

        public override async Task<UserInOrganizationDetailDto> Execute(Expression<Func<UserInOrganizationDbo, bool>> predicate, List<string> culture, Dictionary<string, object>? replace = null)
        {
            List<UserInOrganizationDbo> getUserOrganizationRoles = await _repository.GetEntities(false, predicate);
            UserInOrganizationDetailDto result =
                new()
                {
                    RoleId = getUserOrganizationRoles.Select(x => x.OrganizationRoleId).ToList(),
                    Id = getUserOrganizationRoles.FirstOrDefault().UserId,
                    Role = getUserOrganizationRoles.Select(x => x.OrganizationRole.SystemIdentificator).ToList(),
                };
            return result;
        }
    }
}
