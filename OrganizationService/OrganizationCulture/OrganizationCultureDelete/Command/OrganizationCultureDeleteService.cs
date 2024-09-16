using Core.Base.Command.Delete;
using Core.Constants;
using Core.DataTypes;
using Model.Link;
using Repository.OrganizationCulture;

namespace OrganizationService.OrganizationCulture.OrganizationCultureDelete.Command
{
    public class OrganizationCultureDeleteService
        : BaseDeleteCommand<OrganizationCultureDbo, IOrganizationCultureRepository>,
            IOrganizationCultureDeleteService
    {
        public OrganizationCultureDeleteService(IOrganizationCultureRepository repository)
            : base(repository) { }

        public override async Task<Result> Execute(Guid objectId, Guid userId)
        {
            OrganizationCultureDbo organizationCulture = await _repository.GetEntity(objectId);
            if (organizationCulture.IsDefault == true)
            {
                Result result = new();
                result.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION_CULTURE, Constants.CAN_NOT_DELETE_DEFAULT_CULTURE)
                );
                return await Task.FromResult(result);
            }
            await _repository.DeleteEntity(organizationCulture, userId);
            return await Task.FromResult(new Result());
        }
    }
}
