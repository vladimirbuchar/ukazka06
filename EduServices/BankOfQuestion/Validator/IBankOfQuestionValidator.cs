using Core.Base.Validator;
using Model.Edu.BankOfQuestions;
using Repository.BankOfQuestionRepository;
using Services.BankOfQuestion.Dto;

namespace Services.BankOfQuestion.Validator
{
    public interface IBankOfQuestionValidator
        : IBaseValidator<BankOfQuestionDbo, IBankOfQuestionRepository, BankOfQuestionCreateDto, BankOfQuestionDetailDto, BankOfQuestionUpdateDto> { }
}
