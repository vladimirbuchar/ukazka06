using System;
using Core.Base.Service;
using Core.DataTypes;
using EduRepository.OrganizationCultureRepository;
using EduServices.OrganizationCulture.Convertor;
using EduServices.OrganizationCulture.Dto;
using EduServices.OrganizationCulture.Validator;
using Model.Tables.Link;

namespace EduServices.OrganizationCulture.Service
{
    public class OrganizationCultureService(IOrganizationCultureRepository organizationRepository, IOrganizationCultureConvertor organizationSettingConvertor, IOrganizationCultureValidator validator)
        : BaseService<
            IOrganizationCultureRepository,
            OrganizationCultureDbo,
            IOrganizationCultureConvertor,
            IOrganizationCultureValidator,
            OrganizationCultureCreateDto,
            OrganizationCultureListDto,
            OrganizationCultureDetailDto,
            OrganizationCultureUpdateDto
        >(organizationRepository, organizationSettingConvertor, validator),
            IOrganizationCultureService
    {
        public override void DeleteObject(Guid objectId, Guid userId)
        {
            OrganizationCultureDbo organizationCulture = _repository.GetEntity(objectId);
            if (organizationCulture.IsDefault == false)
            {
                _repository.DeleteEntity(organizationCulture, userId);
            }
        }
    }
}
