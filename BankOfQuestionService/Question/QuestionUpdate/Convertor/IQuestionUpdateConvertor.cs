using BankOfQuestionService.Question.QuestionUpdate.Dto;
using Core.Base.Convertor;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionUpdate.Convertor
{
    public interface IQuestionUpdateConvertor : IBaseUpdateConvertor<QuestionDbo, QuestionUpdateDto> { }
}
