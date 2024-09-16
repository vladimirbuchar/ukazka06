using CourseMaterialService.CourseMaterial.CourseMaterialDetail.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialDetail.Convertor
{
    public class CourseMaterialDetailConvertor : ICourseMaterialDetailConvertor
    {
        public Task<CourseMaterialDetailDto> ConvertToWebModel(CourseMaterialDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new CourseMaterialDetailDto()
                {
                    Description = detail.CourseMaterialTranslation.FindTranslation(culture)?.Description,
                    Id = detail.Id,
                    Name = detail.CourseMaterialTranslation.FindTranslation(culture)?.Name,
                }
            );
        }
    }
}
