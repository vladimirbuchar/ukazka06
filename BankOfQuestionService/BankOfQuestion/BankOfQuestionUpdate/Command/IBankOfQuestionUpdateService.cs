using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Dto;
using Core.Base.Command.Update;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Command
{
    public interface IBankOfQuestionUpdateService : IBaseUpdateCommand<BankOfQuestionDbo, BankOfQuestionUpdateDto> { }
}
