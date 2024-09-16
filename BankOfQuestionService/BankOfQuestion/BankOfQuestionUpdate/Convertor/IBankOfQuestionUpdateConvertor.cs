using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Dto;
using Core.Base.Convertor;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Convertor
{
    public interface IBankOfQuestionUpdateConvertor : IBaseUpdateConvertor<BankOfQuestionDbo, BankOfQuestionUpdateDto> { }
}
