using System.Collections.Generic;
using System.Linq;
using Core.Base.Repository.CodeBookRepository;
using Core.Constants;
using Microsoft.Extensions.Configuration;
using Model.CodeBook;
using Model.Edu.CourseMaterial;
using Services.CourseMaterial.Dto;

namespace Services.CourseMaterial.Convertor
{
    public class CourseMaterialConvertor(IConfiguration configuration, ICodeBookRepository<CultureDbo> codeBookService) : ICourseMaterialConvertor
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly List<CultureDbo> _cultureList = codeBookService.GetEntities(false).Result;

        public List<CourseMaterialListDto> ConvertToWebModel(List<CourseMaterialDbo> getCourseMaterialInOrganizations, string culture)
        {
            return getCourseMaterialInOrganizations
                .Select(x => new CourseMaterialListDto()
                {
                    Description = x.CourseMaterialTranslation.FindTranslation(culture)?.Description,
                    Name = x.CourseMaterialTranslation.FindTranslation(culture)?.Name,
                    Id = x.Id
                })
                .ToList();
        }

        public CourseMaterialDetailDto ConvertToWebModel(CourseMaterialDbo getCourseMaterialDetail, string culture)
        {
            return new CourseMaterialDetailDto()
            {
                Description = getCourseMaterialDetail.CourseMaterialTranslation.FindTranslation(culture)?.Description,
                Id = getCourseMaterialDetail.Id,
                Name = getCourseMaterialDetail.CourseMaterialTranslation.FindTranslation(culture)?.Name,
            };
        }

        public List<CourseMaterialFileListDto> ConvertToWebModel(List<CourseMaterialFileRepositoryDbo> getFiles)
        {
            return getFiles
                .Select(x => new CourseMaterialFileListDto()
                {
                    FileName = x.FileName,
                    Id = x.Id,
                    ObjectOwner = x.CourseMaterialId,
                    OriginalFileName = x.OriginalFileName,
                    Url = string.Format("{0}{1}/{2}", _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value, x.CourseMaterialId, x.FileName)
                })
                .ToList();
        }

        public CourseMaterialDbo ConvertToBussinessEntity(CourseMaterialCreateDto create, string culture)
        {
            CourseMaterialDbo material = new() { OrganizationId = create.OrganizationId };
            material.CourseMaterialTranslation = material.CourseMaterialTranslation.PrepareTranslation(
                create.Name,
                create.Description,
                culture,
                _cultureList
            );
            return material;
        }

        public CourseMaterialDbo ConvertToBussinessEntity(CourseMaterialUpdateDto update, CourseMaterialDbo entity, string culture)
        {
            entity.CourseMaterialTranslation = entity.CourseMaterialTranslation.PrepareTranslation(
                update.Name,
                update.Description,
                culture,
                _cultureList
            );
            return entity;
        }
    }
}
