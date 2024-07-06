using Core.Base.Validator;
using EduRepository.BankOfQuestionRepository;
using EduServices.BankOfQuestion.Dto;
using Model.Edu.BankOfQuestions;

namespace EduServices.BankOfQuestion.Validator
{
    public interface IBankOfQuestionValidator : IBaseValidator<BankOfQuestionDbo, IBankOfQuestionRepository, BankOfQuestionCreateDto, BankOfQuestionDetailDto, BankOfQuestionUpdateDto> { }
}
