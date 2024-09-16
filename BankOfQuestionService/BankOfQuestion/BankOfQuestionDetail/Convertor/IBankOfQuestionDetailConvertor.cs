using BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Dto;
using Core.Base.Convertor;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Convertor
{
    public interface IBankOfQuestionDetailConvertor : IBaseDetailConvertor<BankOfQuestionDbo, BankOfQuestionDetailDto> { }
}
