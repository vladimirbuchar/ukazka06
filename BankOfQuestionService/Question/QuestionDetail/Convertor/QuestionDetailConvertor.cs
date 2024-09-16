using BankOfQuestionService.Question.QuestionDetail.Dto;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionDetail.Convertor
{
    public class QuestionDetailConvertor : IQuestionDetailConvertor
    {
        public Task<QuestionDetailDto> ConvertToWebModel(QuestionDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new QuestionDetailDto()
                {
                    AnswerModeId = detail.AnswerModeId,
                    Id = detail.Id,
                    Question = detail.TestQuestionTranslation.FindTranslation(culture).Question,
                    BankOfQuestionId = detail.BankOfQuestionId,
                    QuestionModeId = detail.QuestionModeId,
                    FileId = detail.QuestionFileRepositories.FindTranslation(culture)?.Id,
                    OriginalFileName = detail.QuestionFileRepositories.FindTranslation(culture)?.OriginalFileName
                }
            );
        }
    }
}
