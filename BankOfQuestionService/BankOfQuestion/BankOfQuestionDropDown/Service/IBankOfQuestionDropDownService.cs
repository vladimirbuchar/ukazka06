using BankOfQuestionService.BankOfQuestion.BankOfQuestionDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionDropDown.Service
{
    public interface IBankOfQuestionDropDownService : IBaseDropDownCommand<BankOfQuestionDbo, BankOfQuestionDropDownDto>
    {
    }
}