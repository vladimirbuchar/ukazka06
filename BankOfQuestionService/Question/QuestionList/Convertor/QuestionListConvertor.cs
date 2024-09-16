using BankOfQuestionService.Answer.AnswerList.Dto;
using BankOfQuestionService.Question.QuestionList.Dto;
using Model.Edu.Answer;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionList.Convertor
{
    public class QuestionListConvertor : IQuestionListConvertor
    {
        public Task<List<QuestionListDto>> ConvertToWebModel(List<QuestionDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new QuestionListDto()
                {
                    AnswerModeId = item.AnswerModeId,
                    Id = item.Id,
                    Question = item.TestQuestionTranslation?.FindTranslation(culture)?.Question,
                    AnswerModeName = item.AnswerMode.Name,
                    QuestionModeId = item.QuestionModeId,
                    QuestionModeName = item.QuestionMode.Name,
                    Position = item.Position,
                    FileName = item.QuestionFileRepositories.FindTranslation(culture)?.FileName,
                    TestQuestionAnswer = item.TestQuestionAnswer.Select(x => new AnswerListDto()
                    {
                        Answer = x.TestQuestionAnswerTranslations.FindTranslation(culture).Answer,
                        Id = x.Id,
                        IsTrueAnswer = x.IsTrueAnswer,

                    }).ToList()

                })
                    .ToList()
            );
        }
    }
}
