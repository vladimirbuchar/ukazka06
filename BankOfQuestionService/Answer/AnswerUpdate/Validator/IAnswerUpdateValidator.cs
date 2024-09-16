using BankOfQuestionService.Answer.AnswerUpdate.Dto;
using Core.Base.Validator;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerUpdate.Validator
{
    public interface IAnswerUpdateValidator : IBaseUpdateValidator<AnswerDbo, AnswerUpdateDto> { }
}
