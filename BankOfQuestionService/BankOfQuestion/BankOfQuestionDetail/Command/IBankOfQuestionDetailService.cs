using BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Dto;
using Core.Base.Command.Detail;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Command
{
    public interface IBankOfQuestionDetailService : IBaseDetailCommand<BankOfQuestionDbo, BankOfQuestionDetailDto> { }
}
