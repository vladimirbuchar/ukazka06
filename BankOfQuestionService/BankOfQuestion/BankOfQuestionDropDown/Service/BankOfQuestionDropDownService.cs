using BankOfQuestionService.BankOfQuestion.BankOfQuestionDropDown.Convertor;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.Edu.BankOfQuestions;
using Repository.BankOfQuestion;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionDropDown.Service
{
    public class BankOfQuestionDropDownService : BaseDropDownCommand<BankOfQuestionDbo, IBankOfQuestionRepository, BankOfQuestionDropDownDto, IBankOfQuestionDropDownConvertor>, IBankOfQuestionDropDownService
    {
        public BankOfQuestionDropDownService(IBankOfQuestionRepository repository, IBankOfQuestionDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
