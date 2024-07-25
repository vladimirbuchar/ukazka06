using Core.Base.Repository.CodeBookRepository;
using Core.Constants;
using Microsoft.Extensions.Configuration;
using Model.CodeBook;
using Model.Edu.CourseMaterial;
using Services.CourseMaterial.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.CourseMaterial.Convertor
{
    public class CourseMaterialConvertor(IConfiguration configuration, ICodeBookRepository<CultureDbo> codeBookRepository) : ICourseMaterialConvertor
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly List<CultureDbo> _cultureList = codeBookRepository.GetEntities(false).Result;

        public Task<List<CourseMaterialListDto>> ConvertToWebModel(List<CourseMaterialDbo> getCourseMaterialInOrganizations, string culture)
        {
            return Task.FromResult(getCourseMaterialInOrganizations
                .Select(x => new CourseMaterialListDto()
                {
                    Name = x.CourseMaterialTranslation.FindTranslation(culture)?.Name,
                    Id = x.Id
                })
                .ToList());
        }

        public Task<CourseMaterialDetailDto> ConvertToWebModel(CourseMaterialDbo getCourseMaterialDetail, string culture)
        {
            return Task.FromResult(new CourseMaterialDetailDto()
            {
                Description = getCourseMaterialDetail.CourseMaterialTranslation.FindTranslation(culture)?.Description,
                Id = getCourseMaterialDetail.Id,
                Name = getCourseMaterialDetail.CourseMaterialTranslation.FindTranslation(culture)?.Name,
            });
        }

        public Task<List<CourseMaterialFileListDto>> ConvertToWebModel(List<CourseMaterialFileRepositoryDbo> getFiles)
        {
            return Task.FromResult(getFiles
                .Select(x => new CourseMaterialFileListDto()
                {
                    FileName = x.FileName,
                    Id = x.Id,
                    ObjectOwner = x.CourseMaterialId,
                    OriginalFileName = x.OriginalFileName,
                    Url = string.Format("{0}{1}/{2}", _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value, x.CourseMaterialId, x.FileName)
                })
                .ToList());
        }

        public Task<CourseMaterialDbo> ConvertToBussinessEntity(CourseMaterialCreateDto create, string culture)
        {
            CourseMaterialDbo material = new() { OrganizationId = create.OrganizationId };
            material.CourseMaterialTranslation = material.CourseMaterialTranslation.PrepareTranslation(
                create.Name,
                create.Description,
                culture,
                _cultureList
            );
            return Task.FromResult(material);
        }

        public Task<CourseMaterialDbo> ConvertToBussinessEntity(CourseMaterialUpdateDto update, CourseMaterialDbo entity, string culture)
        {
            entity.CourseMaterialTranslation = entity.CourseMaterialTranslation.PrepareTranslation(
                update.Name,
                update.Description,
                culture,
                _cultureList
            );
            return Task.FromResult(entity);
        }
    }
}
