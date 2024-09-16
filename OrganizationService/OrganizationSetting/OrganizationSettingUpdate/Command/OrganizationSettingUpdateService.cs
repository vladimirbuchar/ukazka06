using Core.Base.Command.Update;
using Core.DataTypes;
using Model.Edu.LicenseChange;
using Model.Edu.Organization;
using Model.Edu.OrganizationSetting;
using OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Convertor;
using OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Dto;
using OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Validator;
using Repository.LicenseChange;
using Repository.Organization;
using Repository.OrganizationSetting;

namespace OrganizationService.OrganizationSetting.OrganizationSettingUpdate.Command
{
    public class OrganizationSettingUpdateService
        : BaseUpdateCommand<
            OrganizationSettingDbo,
            IOrganizationSettingRepository,
            OrganizationSettingUpdateDto,
            IOrganizationSettingUpdateConvertor,
            IOrganizationSettingUpdateValidator

        >,
            IOrganizationSettingUpdateService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ILicenseChangeRepository _licenseChangeRepository;

        public OrganizationSettingUpdateService(
            ILicenseChangeRepository licenseChangeRepository,
            IOrganizationRepository organizationRepository,
            IOrganizationSettingRepository repository,
            IOrganizationSettingUpdateConvertor convertor,
            IOrganizationSettingUpdateValidator validator
        )
            : base(repository, convertor, validator)
        {
            _organizationRepository = organizationRepository;
            _licenseChangeRepository = licenseChangeRepository;
        }

        public override async Task<Result> Execute(OrganizationSettingUpdateDto update, Guid userId, string culture, Result? result = null)
        {
            Result validate = await _validator.IsValid(update);
            if (validate.IsOk)
            {
                OrganizationSettingDbo setting = await _repository.GetEntity(false, x => x.OrganizationId == update.OrganizationId);
                _ = await _repository.UpdateEntity(await _convertor.ConvertToBussinessEntity(update, setting, culture), Guid.Empty);
                OrganizationDbo organization = await _organizationRepository.GetEntity(update.OrganizationId);
                if (organization.LicenseId != update.LicenseId)
                {
                    _ = await _licenseChangeRepository.CreateEntity(
                        new LicenseChangeDbo()
                        {
                            OrganizationId = update.OrganizationId,
                            LicenseOldId = organization.LicenseId,
                            LicenseChange = DateTime.Now
                        },
                        Guid.Empty
                    );

                    organization.LicenseId = update.LicenseId;
                    _ = await _organizationRepository.UpdateEntity(organization, Guid.Empty);
                }
            }
            return validate;
        }
    }
}
