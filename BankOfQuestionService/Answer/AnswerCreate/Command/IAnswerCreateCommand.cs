using BankOfQuestionService.Answer.AnswerCreate.Dto;
using Core.Base.Command.Create;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerCreate.Command
{
    public interface IAnswerCreateCommand : IBaseCreateCommand<AnswerDbo, AnswerCreateDto> { }
}
