using EduServices.OrganizationCulture.Dto;
using Model.Link;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.OrganizationCulture.Convertor
{
    public class OrganizationCultureConvertor : IOrganizationCultureConvertor
    {
        public OrganizationCultureConvertor() { }

        public OrganizationCultureDbo ConvertToBussinessEntity(OrganizationCultureCreateDto create, string culture)
        {
            return new OrganizationCultureDbo()
            {
                OrganizationId = create.OrganizationId,
                CultureId = create.CultureId,
                IsDefault = create.IsDefault
            };
        }

        public OrganizationCultureDbo ConvertToBussinessEntity(OrganizationCultureUpdateDto update, OrganizationCultureDbo entity, string culture)
        {
            entity.IsDefault = update.IsDefault;
            return entity;
        }

        public HashSet<OrganizationCultureListDto> ConvertToWebModel(HashSet<OrganizationCultureDbo> list, string culture)
        {
            return list.Select(item => new OrganizationCultureListDto()
            {
                Id = item.Id,
                IsDefault = item.IsDefault,
                Name = item.Culture.Name,
                CultureId = item.CultureId
            })
                .ToHashSet();
        }

        public OrganizationCultureDetailDto ConvertToWebModel(OrganizationCultureDbo detail, string culture)
        {
            return new OrganizationCultureDetailDto()
            {
                Id = detail.Id,
                IsDefault = detail.IsDefault,
                Name = detail.Culture.Name
            };
        }
    }
}
