using CodebookService.QuestionModeDropDown.Dto;
using Model.CodeBook;

namespace CodebookService.QuestionModeDropDown.Convertor
{
    public class QuestionModeDropDownConvertor : IQuestionModeDropDownConvertor
    {
        public Task<List<QuestionModeDropDownDto>> ConvertToWebModel(List<QuestionModeDbo> list, List<string> culture)
        {
            return Task.FromResult(list
             .Select(item => new QuestionModeDropDownDto()
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
