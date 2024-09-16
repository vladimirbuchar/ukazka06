using BankOfQuestionService.Question.QuestionList.Dto;
using BankOfQuestionService.Question.QuestionList.Filter;
using Core.Base.Command.List;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionList.Command
{
    public interface IQuestionListService : IBaseListCommand<QuestionDbo, QuestionListDto, QuestionFilter> { }
}
