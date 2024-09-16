using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Dto;
using Core.Base.Convertor;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Convertor
{
    public interface IBankOfQuestionCreateConvertor : IBaseCreateConvertor<BankOfQuestionDbo, BankOfQuestionCreateDto> { }
}
