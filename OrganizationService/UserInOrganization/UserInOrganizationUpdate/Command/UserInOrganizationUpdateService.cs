using Core.Base.Command.Update;
using Core.DataTypes;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationUpdate.Dto;
using OrganizationService.UserInOrganization.UserInOrganizationUpdate.Vadlidator;
using Repository.UserInOrganization;

namespace OrganizationService.UserInOrganization.UserInOrganizationUpdate.Command
{
    public class UserInOrganizationUpdateService
        : BaseUpdateCommand<UserInOrganizationDbo, IUserInOrganizationRepository, UserInOrganizationUpdateDto, IUserInOrganizationUpdateValidator>,
            IUserInOrganizationUpdateService
    {
        public UserInOrganizationUpdateService(IUserInOrganizationRepository repository)
            : base(repository) { }

        public override async Task<Result> Execute(UserInOrganizationUpdateDto update, Guid userId, string culture, Result? result = null)
        {
            List<UserInOrganizationDbo> getUserOrganizationRoles = await _repository.GetEntities(
                false,
                x => x.UserId == update.Id && x.OrganizationId == update.OrganizationId
            );

            if (getUserOrganizationRoles.Where(x => x.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER).ToList().Count > 0)
            {
                return new Result();
            }
            foreach (UserInOrganizationDbo item in getUserOrganizationRoles)
            {
                if (!update.OrganizationRoleId.Contains(item.Id))
                {
                    await _repository.DeleteEntity(item.Id, userId);
                }
            }
            foreach (Guid role in update.OrganizationRoleId)
            {
                UserInOrganizationDbo entity = getUserOrganizationRoles.FirstOrDefault(x => x.Id == role);
                if (entity == null)
                {
                    _ = await _repository.CreateEntity(
                        new UserInOrganizationDbo()
                        {
                            OrganizationId = update.OrganizationId,
                            OrganizationRoleId = role,
                            UserId = update.Id
                        },
                        Guid.Empty
                    );
                }
                else if (entity.IsDeleted)
                {
                    await _repository.RestoreEntity(entity.Id, userId);
                }
            }
            return new Result();
        }
    }
}
