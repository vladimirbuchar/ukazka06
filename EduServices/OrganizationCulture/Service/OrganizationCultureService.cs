using Core.Base.Service;
using Core.DataTypes;
using EduRepository.OrganizationCultureRepository;
using EduServices.OrganizationCulture.Convertor;
using EduServices.OrganizationCulture.Dto;
using EduServices.OrganizationCulture.Validator;
using Model.Tables.Link;
using System;

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
        public override Result DeleteObject(Guid objectId, Guid userId)
        {
            OrganizationCultureDbo organizationCulture = _repository.GetEntity(objectId);
            if (organizationCulture.IsDefault == false)
            {
                _repository.DeleteEntity(organizationCulture, userId);
            }
            return new Result();
        }
        public override Result<OrganizationCultureDetailDto> UpdateObject(OrganizationCultureUpdateDto update, Guid userId, string culture, Result<OrganizationCultureDetailDto> result = null)
        {
            result = _validator.IsValid(update);
            if (result.IsOk)
            {
                if (update.IsDefault == true)
                {
                    OrganizationCultureDbo organizationCulture = _repository.GetEntity(false, x => x.OrganizationId == update.OrganizationId && x.IsDefault == true);
                    organizationCulture.IsDefault = false;
                    _ = _repository.UpdateEntity(organizationCulture, userId);
                }
                return base.UpdateObject(update, userId, culture, result);
            }
            return result;
        }

    }
}
