using Core.Base.Command.Update;
using Core.Constants;
using Core.DataTypes;
using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Convertor;
using OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Dto;
using OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Validator;
using Repository.OrganizationCulture;

namespace OrganizationService.OrganizationCulture.OrganizationCultureUpdate.Command
{
    public class OrganizationCultureUpdateService
        : BaseUpdateCommand<
            OrganizationCultureDbo,
            IOrganizationCultureRepository,
            OrganizationCultureUpdateDto,
              IOrganizationCultureUpdateConvertor,
            IOrganizationCultureUpdateValidator

        >,
            IOrganizationCultureUpdateService
    {
        public OrganizationCultureUpdateService(
            IOrganizationCultureRepository repository,
            IOrganizationCultureUpdateConvertor convertor,
            IOrganizationCultureUpdateValidator validator
        )
            : base(repository, convertor, validator) { }

        public override async Task<Result> Execute(OrganizationCultureUpdateDto update, Guid userId, string culture, Result? result = null)
        {
            result = await _validator.IsValid(update);
            if (result.IsOk)
            {
                OrganizationCultureDbo organizationCulture = await _repository.GetEntity(
                    false,
                    x => x.OrganizationId == update.OrganizationId && x.IsDefault == true
                );
                if (update.IsDefault == true)
                {
                    if (organizationCulture != null)
                    {
                        organizationCulture.IsDefault = false;
                        _ = await _repository.UpdateEntity(organizationCulture, userId);
                    }
                }
                else if (update.IsDefault == false)
                {
                    if (organizationCulture.IsDefault)
                    {
                        result.AddResultStatus(
                            new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION_CULTURE, MessageItem.CAN_NOT_EDIT)
                        );
                    }
                }

                return await base.Execute(update, userId, culture, result);
            }
            return result;
        }
    }
}
