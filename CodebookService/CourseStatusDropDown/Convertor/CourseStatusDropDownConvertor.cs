using CodebookService.CourseStatusDropDown.Dto;
using Model.CodeBook;

namespace CodebookService.CourseStatusDropDown.Convertor
{
    public class CourseStatusDropDownConvertor : ICourseStatusDropDownConvertor
    {
        public Task<List<CourseStatusDropDownDto>> ConvertToWebModel(List<CourseStatusDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(item => new CourseStatusDropDownDto()
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
