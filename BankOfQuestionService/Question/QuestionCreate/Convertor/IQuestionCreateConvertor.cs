using BankOfQuestionService.Question.QuestionCreate.Dto;
using Core.Base.Convertor;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionCreate.Convertor
{
    public interface IQuestionCreateConvertor : IBaseCreateConvertor<QuestionDbo, QuestionCreateDto> { }
}
