using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Dto;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Convertor
{
    public class BankOfQuestionUpdateConvertor : IBankOfQuestionUpdateConvertor
    {
        public Task<BankOfQuestionDbo> ConvertToBussinessEntity(BankOfQuestionUpdateDto update, BankOfQuestionDbo entity, string culture)
        {
            entity.BankOfQuestionsTranslations = entity.BankOfQuestionsTranslations.PrepareTranslation(update.Name, update.CultureId);
            return Task.FromResult(entity);
        }
    }
}
