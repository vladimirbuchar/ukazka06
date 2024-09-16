using Core.Base.Command.Delete;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.User;
using Repository.User;
using Repository.UserInOrganization;

namespace UserService.User.UserDelete.Command
{
    public class UserDeleteService : BaseDeleteCommand<UserDbo, IUserRepository>, IUserDeleteService
    {
        private readonly IUserInOrganizationRepository _userInOrganizationRepository;

        public UserDeleteService(IUserRepository repository, IUserInOrganizationRepository userInOrganizationRepository)
            : base(repository)
        {
            _userInOrganizationRepository = userInOrganizationRepository;
        }

        public override async Task<Result> Execute(Guid objectId, Guid userId)
        {
            if (
                await _userInOrganizationRepository.GetEntity(
                    false,
                    x => x.UserId == objectId && x.OrganizationRole.SystemIdentificator == OrganizationRole.ORGANIZATION_OWNER
                ) == null
            )
            {
                return await base.Execute(objectId, userId);
            }
            Result result = new();
            result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER, MessageItem.CAN_NOT_DELETE));
            return result;
        }
    }
}
