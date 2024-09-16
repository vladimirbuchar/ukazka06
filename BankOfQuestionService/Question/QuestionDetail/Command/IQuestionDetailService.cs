using BankOfQuestionService.Question.QuestionDetail.Dto;
using Core.Base.Command.Detail;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionDetail.Command
{
    public interface IQuestionDetailService : IBaseDetailCommand<QuestionDbo, QuestionDetailDto> { }
}
