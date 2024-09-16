using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Dto;
using Core.Base.Convertor;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Convertor
{
    public interface IBankOfQuestionListConvertor : IBaseListConvertor<BankOfQuestionDbo, BankOfQuestionListDto> { }
}
