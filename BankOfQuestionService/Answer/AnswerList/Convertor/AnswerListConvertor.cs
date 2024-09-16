using BankOfQuestionService.Answer.AnswerList.Dto;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerList.Convertor
{
    public class AnswerListConvertor : IAnswerListConvertor
    {
        public Task<List<AnswerListDto>> ConvertToWebModel(List<AnswerDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new AnswerListDto()
                {
                    Answer = item.TestQuestionAnswerTranslations.FindTranslation(culture)?.Answer,
                    Id = item.Id,
                    IsTrueAnswer = item.IsTrueAnswer,
                    FileName = item.AnswerFileRepository.FindTranslation(culture)?.FileName,
                })
                    .ToList()
            );
        }
    }
}
