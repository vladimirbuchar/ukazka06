using BankOfQuestionService.Question.QuestionUpdate.Dto;
using Core.Base.Command.Update;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionUpdate.Command
{
    public interface IQuestionUpdateService : IBaseUpdateCommand<QuestionDbo, QuestionUpdateDto> { }
}
