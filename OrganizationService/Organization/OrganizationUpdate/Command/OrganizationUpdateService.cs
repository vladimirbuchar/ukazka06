using Core.Base.Command.Update;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationUpdate.Convertor;
using OrganizationService.Organization.OrganizationUpdate.Dto;
using OrganizationService.Organization.OrganizationUpdate.Validator;
using Repository.Organization;

namespace OrganizationService.Organization.OrganizationUpdate.Command
{
    public class OrganizationUpdateService
        : BaseUpdateCommand<
            OrganizationDbo,
            IOrganizationRepository,
            OrganizationUpdateDto,
            IOrganizationUpdateConvertor,
            IOrganizationUpdateValidator

        >,
            IOrganizationUpdateService
    {
        public OrganizationUpdateService(
            IOrganizationRepository repository,
            IOrganizationUpdateConvertor convertor,
            IOrganizationUpdateValidator validator
        )
            : base(repository, convertor, validator) { }
    }
}
