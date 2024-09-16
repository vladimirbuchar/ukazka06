using BankOfQuestionService.Question.QuestionList.Dto;
using Core.Base.Convertor;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionList.Convertor
{
    public interface IQuestionListConvertor : IBaseListConvertor<QuestionDbo, QuestionListDto> { }
}
