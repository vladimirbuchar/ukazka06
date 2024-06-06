using Core.Base.Service;
using Core.DataTypes;
using EduRepository.LicenseChangeRepository;
using EduRepository.OrganizationRepository;
using EduRepository.OrganizationSettingRepository;
using EduServices.OrganizationSetting.Convertor;
using EduServices.OrganizationSetting.Dto;
using EduServices.OrganizationSetting.Validator;
using Model.Tables.Edu.LicenseChange;
using Model.Tables.Edu.Organization;
using Model.Tables.Edu.OrganizationSetting;
using System;

namespace EduServices.OrganizationSetting.Service
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

        public OrganizationSettingDetailDto GetOrganizationSetting(Guid organizationId)
        {
            return _convertor.ConvertToWebModel(_repository.GetEntity(false, x => x.OrganizationId == organizationId));
        }

        public OrganizationSettingByUrlDto GetOrganizationSettingByUrl(string url)
        {
            return _convertor.ConvertToWebModel2(_repository.GetEntity(false, x => x.ElearningUrl == url));
        }

        public Result SaveOrganizationSetting(OrganizationSettingUpdateDto saveOrganizationSettingDto)
        {
            Result validate = _validator.IsValid(saveOrganizationSettingDto);
            if (validate.IsOk)
            {
                OrganizationSettingDbo setting = _repository.GetEntity(false, x => x.OrganizationId == saveOrganizationSettingDto.OrganizationId);
                _ = _repository.UpdateEntity(_convertor.ConvertToBussinessEntity(saveOrganizationSettingDto, setting), Guid.Empty);
                OrganizationDbo organization = _organizationRepository.GetEntity(saveOrganizationSettingDto.OrganizationId);
                if (organization.LicenseId != saveOrganizationSettingDto.LicenseId)
                {
                    _ = _licenseChangeRepository.CreateEntity(
                        new LicenseChangeDbo()
                        {
                            OrganizationId = saveOrganizationSettingDto.OrganizationId,
                            LicenseOldId = organization.LicenseId,
                            LicenseChange = DateTime.Now
                        },
                        Guid.Empty
                    );

                    organization.LicenseId = saveOrganizationSettingDto.LicenseId;
                    _ = _organizationRepository.UpdateEntity(organization, Guid.Empty);
                }
            }
            return validate;
        }
    }
}
