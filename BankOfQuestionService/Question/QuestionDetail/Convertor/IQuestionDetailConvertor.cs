using BankOfQuestionService.Question.QuestionDetail.Dto;
using Core.Base.Convertor;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionDetail.Convertor
{
    public interface IQuestionDetailConvertor : IBaseDetailConvertor<QuestionDbo, QuestionDetailDto> { }
}
