using CourseMaterialService.CourseMaterial.CourseMaterialList.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialList.Convertor
{
    public class CourseMaterialListConvertor : ICourseMaterialListConvertor
    {
        public Task<List<CourseMaterialListDto>> ConvertToWebModel(List<CourseMaterialDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(x => new CourseMaterialListDto() { Name = x.CourseMaterialTranslation.FindTranslation(culture)?.Name, Id = x.Id })
                    .ToList()
            );
        }
    }
}
