using BankOfQuestionService.Answer.AnswerCreate.Dto;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerCreate.Convertor
{
    public class AnswerCreateConvertor : IAnswerCreateConvertor
    {
        public Task<AnswerDbo> ConvertToBussinessEntity(AnswerCreateDto create, string culture)
        {
            AnswerDbo test = new() { IsTrueAnswer = create.IsTrueAnswer, QuestionId = create.QuestionId };
            test.TestQuestionAnswerTranslations = test.TestQuestionAnswerTranslations.PrepareTranslation(create.AnswerText, create.CultureId);
            return Task.FromResult(test);
        }
    }
}
