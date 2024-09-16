using BankOfQuestionService.Question.QuestionCreate.Dto;
using Core.Base.Validator;
using Model.Edu.Question;

namespace BankOfQuestionService.Question.QuestionCreate.Validator
{
    public interface IQuestionCreateValidator : IBaseCreateValidator<QuestionDbo, QuestionCreateDto> { }
}
