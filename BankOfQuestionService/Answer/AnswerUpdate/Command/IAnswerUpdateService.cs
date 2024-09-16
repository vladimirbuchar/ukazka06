using BankOfQuestionService.Answer.AnswerUpdate.Dto;
using Core.Base.Command.Update;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerUpdate.Command
{
    public interface IAnswerUpdateService : IBaseUpdateCommand<AnswerDbo, AnswerUpdateDto> { }
}
