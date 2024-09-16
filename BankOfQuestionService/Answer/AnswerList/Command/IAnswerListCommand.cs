using BankOfQuestionService.Answer.AnswerList.Dto;
using BankOfQuestionService.Answer.AnswerList.Filter;
using Core.Base.Command.List;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerList.Command
{
    public interface IAnswerListCommand : IBaseListCommand<AnswerDbo, AnswerListDto, AnswerFilter> { }
}
