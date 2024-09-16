using CodebookService.TimeTableDropDown.Dto;
using Model.CodeBook;

namespace CodebookService.TimeTableDropDown.Convertor
{
    public class TimeTableDropDownConvertor : ITimeTableDropDownConvertor
    {
        public Task<List<TimeTableDropDownDto>> ConvertToWebModel(List<TimeTableDbo> list, List<string> culture)
        {
            return Task.FromResult(list
             .Select(item => new TimeTableDropDownDto()
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
