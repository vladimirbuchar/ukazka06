using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Dto;
using Core.Base.Validator;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Validator
{
    public interface IBankOfQuestionUpdateValidator : IBaseUpdateValidator<BankOfQuestionDbo, BankOfQuestionUpdateDto> { }
}
