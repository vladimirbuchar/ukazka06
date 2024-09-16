using BankOfQuestionService.Answer.AnswerUpdate.Dto;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerUpdate.Convertor
{
    public class AnswerUpdateConvertor : IAnswerUpdateConvertor
    {
        public Task<AnswerDbo> ConvertToBussinessEntity(AnswerUpdateDto update, AnswerDbo entity, string culture)
        {
            entity.IsTrueAnswer = update.IsTrueAnswer;
            entity.TestQuestionAnswerTranslations = entity.TestQuestionAnswerTranslations.PrepareTranslation(update.AnswerText, update.CultureId);
            return Task.FromResult(entity);
        }
    }
}
