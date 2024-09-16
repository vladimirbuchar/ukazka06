using BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Dto;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Convertor
{
    public class BankOfQuestionDetailConvertor : IBankOfQuestionDetailConvertor
    {
        public Task<BankOfQuestionDetailDto> ConvertToWebModel(BankOfQuestionDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new BankOfQuestionDetailDto()
                {
                    Name = detail.BankOfQuestionsTranslations.FindTranslation(culture).Name,
                    Id = detail.Id,
                    IsDefault = detail.IsDefault
                }
            );
        }
    }
}
