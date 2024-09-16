using BankOfQuestionService.Question.QuestionUpdate.Dto;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionUpdate.Convertor
{
    public class QuestionUpdateConvertor : IQuestionUpdateConvertor
    {
        public Task<QuestionDbo> ConvertToBussinessEntity(QuestionUpdateDto update, QuestionDbo entity, string culture)
        {
            entity.AnswerModeId = update.AnswerModeId;
            entity.BankOfQuestionId = update.BankOfQuestionId;
            entity.QuestionModeId = update.QuestionModeId;
            entity.TestQuestionTranslation = entity.TestQuestionTranslation.PrepareTranslation(update.Question, update.CultureId);
            return Task.FromResult(entity);
        }
    }
}
