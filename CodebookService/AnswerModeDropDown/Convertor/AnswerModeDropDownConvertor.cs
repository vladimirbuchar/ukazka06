using CodebookService.AnswerModeDropDown.Dto;
using Model.CodeBook;

namespace CodebookService.AnswerModeDropDown.Convertor
{
    public class AnswerModeDropDownConvertor : IAnswerModeDropDownConvertor
    {
        public Task<List<AnswerModeDropDownDto>> ConvertToWebModel(List<AnswerModeDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(item => new AnswerModeDropDownDto()
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
