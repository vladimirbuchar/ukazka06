using Model.Link;
using Services.OrganizationCulture.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.OrganizationCulture.Convertor
{
    public class OrganizationCultureConvertor : IOrganizationCultureConvertor
    {
        public OrganizationCultureConvertor() { }

        public Task<OrganizationCultureDbo> ConvertToBussinessEntity(OrganizationCultureCreateDto create, string culture)
        {
            return Task.FromResult(new OrganizationCultureDbo()
            {
                OrganizationId = create.OrganizationId,
                CultureId = create.CultureId,
                IsDefault = create.IsDefault
            });
        }

        public Task<OrganizationCultureDbo> ConvertToBussinessEntity(OrganizationCultureUpdateDto update, OrganizationCultureDbo entity, string culture)
        {
            entity.IsDefault = update.IsDefault;
            return Task.FromResult(entity);
        }

        public Task<List<OrganizationCultureListDto>> ConvertToWebModel(List<OrganizationCultureDbo> list, string culture)
        {
            return Task.FromResult(list.Select(item => new OrganizationCultureListDto()
            {
                Id = item.Id,
                IsDefault = item.IsDefault,
                Name = item.Culture.Name,
                CultureId = item.CultureId
            })
                .ToList());
        }

        public Task<OrganizationCultureDetailDto> ConvertToWebModel(OrganizationCultureDbo detail, string culture)
        {
            return Task.FromResult(new OrganizationCultureDetailDto()
            {
                Id = detail.Id,
                IsDefault = detail.IsDefault,
                Name = detail.Culture.Name
            });
        }
    }
}
