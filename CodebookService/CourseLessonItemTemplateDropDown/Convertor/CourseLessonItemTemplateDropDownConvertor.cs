using CodebookService.CourseLessonItemTemplateDropDown.Dto;
using Model.CodeBook;

namespace CodebookService.CourseLessonItemTemplateDropDown.Convertor
{
    public class CourseLessonItemTemplateDropDownConvertor : ICourseLessonItemTemplateDropDownConvertor
    {
        public Task<List<CourseLessonItemTemplateDropDownDto>> ConvertToWebModel(List<CourseLessonItemTemplateDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(item => new CourseLessonItemTemplateDropDownDto()
            {
                Id = item.Id,
                IsDefault = item.IsDefault,
                Name = item.Name,
                SystemIdentificator = item.SystemIdentificator
            })
           .ToList());
        }
    }
}
