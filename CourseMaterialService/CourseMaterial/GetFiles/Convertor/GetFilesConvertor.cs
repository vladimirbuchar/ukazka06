using Core.Constants;
using CourseMaterialService.CourseMaterial.GetFiles.Dto;
using Microsoft.Extensions.Configuration;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.GetFiles.Convertor
{
    public class GetFilesConvertor : IGetFilesConvertor
    {
        private readonly IConfiguration _configuration;

        public GetFilesConvertor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<List<CourseMaterialFileListDto>> ConvertToWebModel(List<CourseMaterialFileRepositoryDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(x => new CourseMaterialFileListDto()
                {
                    FileName = x.FileName,
                    Id = x.Id,
                    ObjectOwner = x.CourseMaterialId,
                    OriginalFileName = x.OriginalFileName,
                    Url = string.Format(
                            "{0}{1}/{2}",
                            _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value,
                            x.CourseMaterialId,
                            x.FileName
                        )
                })
                    .ToList()
            );
        }
    }
}
