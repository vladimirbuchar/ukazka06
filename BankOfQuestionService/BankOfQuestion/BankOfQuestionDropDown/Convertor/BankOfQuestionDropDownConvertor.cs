using BankOfQuestionService.BankOfQuestion.BankOfQuestionDropDown.Dto;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionDropDown.Convertor
{
    public class BankOfQuestionDropDownConvertor : IBankOfQuestionDropDownConvertor
    {
        public Task<List<BankOfQuestionDropDownDto>> ConvertToWebModel(List<BankOfQuestionDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new BankOfQuestionDropDownDto()
            {
                Id = x.Id,
                Name = x.BankOfQuestionsTranslations.FindTranslation(culture).Name,
                IsDefault = x.IsDefault
            }).ToList());
        }
    }
}
