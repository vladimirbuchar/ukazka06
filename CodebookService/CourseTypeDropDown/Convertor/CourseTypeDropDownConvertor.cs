using CodebookService.CourseTypeDropDown.Dto;
using Model.CodeBook;

namespace CodebookService.CourseTypeDropDown.Convertor
{
    public class CourseTypeDropDownConvertor : ICourseTypeDropDownConvertor
    {
        public Task<List<CourseTypeDropDownDto>> ConvertToWebModel(List<CourseTypeDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(item => new CourseTypeDropDownDto()
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
