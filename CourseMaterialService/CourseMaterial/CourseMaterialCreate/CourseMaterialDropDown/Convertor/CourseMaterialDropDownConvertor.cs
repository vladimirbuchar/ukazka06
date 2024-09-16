using CourseMaterialService.CourseMaterial.CourseMaterialCreate.CourseMaterialDropDown.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialCreate.CourseMaterialDropDown.Convertor
{
    public class CourseMaterialDropDownConvertor : ICourseMaterialDropDownConvertor
    {
        public Task<List<CourseMaterialDropDownDto>> ConvertToWebModel(List<CourseMaterialDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new CourseMaterialDropDownDto()
            {
                Id = x.Id,
                Name = x.CourseMaterialTranslation.FindTranslation(culture).Name
            }).ToList());
        }
    }
}
