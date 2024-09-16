using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationCreate.Convertor;
using OrganizationService.Organization.OrganizationCreate.Dto;
using OrganizationService.Organization.OrganizationCreate.Validator;
using Repository.Organization;
using Repository.OrganizationRole;

namespace OrganizationService.Organization.OrganizationCreate.Command
{
    public class OrganizationCreateService
        : BaseCreateCommand<
            OrganizationDbo,
            IOrganizationRepository,
            OrganizationCreateDto,
            IOrganizationCreateConvertor,
            IOrganizationCreateValidator
        >,
            IOrganizationCreateService
    {
        private readonly IOrganizationRoleRepository _organizationRoleRepository;
        private readonly ICodeBookRepository<LicenseDbo> _licenceDbo;
        private readonly string _elearningUrl = "";

        public OrganizationCreateService(
            Microsoft.Extensions.Configuration.IConfiguration configuration,
            ICodeBookRepository<LicenseDbo> licenceDbo,
            IOrganizationRoleRepository organizationRoleRepository,
            IOrganizationRepository repository,
            IOrganizationCreateConvertor convertor,
            IOrganizationCreateValidator validator
        )
            : base(repository, convertor, validator)
        {
            _organizationRoleRepository = organizationRoleRepository;
            _licenceDbo = licenceDbo;
            _elearningUrl = configuration.GetSection(ConfigValue.ELEARNING_URL).Value;
        }

        public override async Task<ResultInsert> Execute(OrganizationCreateDto addObject, Guid userId, string culture)
        {
            addObject.UserId = userId;
            addObject.OranizationRoleOwnerId = (
                await _organizationRoleRepository.GetEntity(false, x => x.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER)
            ).Id;
            addObject.LicenceId = (await _licenceDbo.GetEntity(false, x => x.SystemIdentificator == License.FREE)).Id;
            addObject.ElearningUrl = string.Format("{0}{1}", _elearningUrl, Guid.NewGuid().ToString());
            return await base.Execute(addObject, userId, culture);
        }
    }
}
