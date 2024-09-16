using BankOfQuestionService.Answer.AnswerDetail.Dto;
using Core.Base.Command.Detail;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerDetail.Command
{
    public interface IAnswerDetailCommand : IBaseDetailCommand<AnswerDbo, AnswerDetailDto> { }
}
