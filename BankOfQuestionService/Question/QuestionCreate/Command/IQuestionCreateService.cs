using BankOfQuestionService.Question.QuestionCreate.Dto;
using Core.Base.Command.Create;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionCreate.Command
{
    public interface IQuestionCreateService : IBaseCreateCommand<QuestionDbo, QuestionCreateDto> { }
}
