using BankOfQuestionService.Question.QuestionUpdate.Dto;
using Core.Base.Validator;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionUpdate.Validator
{
    public interface IQuestionUpdateValidator : IBaseUpdateValidator<QuestionDbo, QuestionUpdateDto> { }
}
