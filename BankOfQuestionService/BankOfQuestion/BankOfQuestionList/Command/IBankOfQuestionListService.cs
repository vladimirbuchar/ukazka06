using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Dto;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Filter;
using Core.Base.Command.List;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Command
{
    public interface IBankOfQuestionListService : IBaseListCommand<BankOfQuestionDbo, BankOfQuestionListDto, BankOfQuestionFilter> { }
}
