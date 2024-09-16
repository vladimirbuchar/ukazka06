using BankOfQuestionService.Answer.AnswerCreate.Dto;
using Core.Base.Validator;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerCreate.Validator
{
    public interface IAnswerCreateValidator : IBaseCreateValidator<AnswerDbo, AnswerCreateDto> { }
}
