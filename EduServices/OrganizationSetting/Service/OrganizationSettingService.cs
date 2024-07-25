using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.LicenseChange;
using Model.Edu.Organization;
using Model.Edu.OrganizationSetting;
using Repository.LicenseChangeRepository;
using Repository.OrganizationRepository;
using Repository.OrganizationSettingRepository;
using Services.OrganizationSetting.Convertor;
using Services.OrganizationSetting.Dto;
using Services.OrganizationSetting.Validator;
using System;
using System.Threading.Tasks;

namespace Services.OrganizationSetting.Service
{
    public class OrganizationSettingService(
        ILicenseChangeRepository licenseChangeRepository,
        IOrganizationRepository organizationRepository,
        IOrganizationSettingRepository organizationSettingRepository,
        IOrganizationSettingConvertor organizationSettingConvertor,
        IOrganizationSettingValidator validator
    )
        : BaseService<IOrganizationSettingRepository, OrganizationSettingDbo, IOrganizationSettingConvertor, IOrganizationSettingValidator>(
            organizationSettingRepository,
            organizationSettingConvertor,
            validator
        ),
            IOrganizationSettingService
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;
        private readonly ILicenseChangeRepository _licenseChangeRepository = licenseChangeRepository;

        public async Task<OrganizationSettingDetailDto> GetOrganizationSetting(Guid organizationId)
        {
            return _convertor.ConvertToWebModel(await _repository.GetEntity(false, x => x.OrganizationId == organizationId));
        }

        public async Task<OrganizationSettingByUrlDto> GetOrganizationSettingByUrl(string url)
        {
            return _convertor.ConvertToWebModel2(await _repository.GetEntity(false, x => x.ElearningUrl == url));
        }

        public async Task<Result> SaveOrganizationSetting(OrganizationSettingUpdateDto saveOrganizationSettingDto)
        {
            Result validate = await _validator.IsValid(saveOrganizationSettingDto);
            if (validate.IsOk)
            {
                OrganizationSettingDbo setting = await _repository.GetEntity(false, x => x.OrganizationId == saveOrganizationSettingDto.OrganizationId);
                _ = await _repository.UpdateEntity(_convertor.ConvertToBussinessEntity(saveOrganizationSettingDto, setting), Guid.Empty);
                OrganizationDbo organization = await _organizationRepository.GetEntity(saveOrganizationSettingDto.OrganizationId);
                if (organization.LicenseId != saveOrganizationSettingDto.LicenseId)
                {
                    _ = await _licenseChangeRepository.CreateEntity(
                        new LicenseChangeDbo()
                        {
                            OrganizationId = saveOrganizationSettingDto.OrganizationId,
                            LicenseOldId = organization.LicenseId,
                            LicenseChange = DateTime.Now
                        },
                        Guid.Empty
                    );

                    organization.LicenseId = saveOrganizationSettingDto.LicenseId;
                    _ = await _organizationRepository.UpdateEntity(organization, Guid.Empty);
                }
            }
            return validate;
        }
    }
}
