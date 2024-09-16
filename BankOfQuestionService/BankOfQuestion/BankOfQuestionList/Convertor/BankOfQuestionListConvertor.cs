using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Dto;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Convertor
{
    public class BankOfQuestionListConvertor : IBankOfQuestionListConvertor
    {
        public Task<List<BankOfQuestionListDto>> ConvertToWebModel(List<BankOfQuestionDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new BankOfQuestionListDto()
                {
                    Name = item.BankOfQuestionsTranslations.FindTranslation(culture).Name,
                    Id = item.Id,
                    IsDefault = item.IsDefault
                })
                    .ToList()
            );
        }
    }
}
