using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Dto;
using Core.Base.Validator;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Validator
{
    public interface IBankOfQuestionCreateValidator : IBaseCreateValidator<BankOfQuestionDbo, BankOfQuestionCreateDto> { }
}
