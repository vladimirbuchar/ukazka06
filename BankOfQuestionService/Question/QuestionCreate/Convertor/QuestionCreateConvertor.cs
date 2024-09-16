using BankOfQuestionService.Question.QuestionCreate.Dto;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionCreate.Convertor
{
    public class QuestionCreateConvertor : IQuestionCreateConvertor
    {
        public Task<QuestionDbo> ConvertToBussinessEntity(QuestionCreateDto create, string culture)
        {
            QuestionDbo question =
                new()
                {
                    AnswerModeId = create.AnswerModeId,
                    BankOfQuestionId = create.BankOfQuestionId,
                    QuestionModeId = create.QuestionModeId
                };
            question.TestQuestionTranslation = question.TestQuestionTranslation.PrepareTranslation(create.Question, create.CultureId);
            return Task.FromResult(question);
        }
    }
}
