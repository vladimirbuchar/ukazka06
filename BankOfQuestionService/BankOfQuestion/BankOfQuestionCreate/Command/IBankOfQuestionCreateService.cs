using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Dto;
using Core.Base.Command.Create;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Command
{
    public interface IBankOfQuestionCreateService : IBaseCreateCommand<BankOfQuestionDbo, BankOfQuestionCreateDto> { }
}
