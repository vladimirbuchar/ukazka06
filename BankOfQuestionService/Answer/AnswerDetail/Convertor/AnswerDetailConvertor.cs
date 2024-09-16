using BankOfQuestionService.Answer.AnswerDetail.Dto;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerDetail.Convertor
{
    public class AnswerDetailConvertor : IAnswerDetailConvertor
    {
        public Task<AnswerDetailDto> ConvertToWebModel(AnswerDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new AnswerDetailDto()
                {
                    Answer = detail.TestQuestionAnswerTranslations.FindTranslation(culture)?.Answer,
                    Id = detail.Id,
                    IsTrueAnswer = detail.IsTrueAnswer,
                    FileId = detail.AnswerFileRepository?.FindTranslation(culture)?.Id,
                    FileName = detail.AnswerFileRepository?.FindTranslation(culture)?.FileName
                }
            );
        }
    }
}
