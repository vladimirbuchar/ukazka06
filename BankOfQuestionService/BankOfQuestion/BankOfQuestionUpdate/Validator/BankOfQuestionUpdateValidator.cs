using BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Dto;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Dto;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.BankOfQuestions;
using Repository.BankOfQuestion;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Validator
{
    public class BankOfQuestionUpdateValidator
        : BaseUpdateValidator<BankOfQuestionDbo, IBankOfQuestionRepository, BankOfQuestionUpdateDto>,
            IBankOfQuestionUpdateValidator
    {
        public BankOfQuestionUpdateValidator(IBankOfQuestionRepository repository)
            : base(repository) { }

        public override async Task<Result> IsValid(BankOfQuestionUpdateDto update)
        {
            Result<BankOfQuestionDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.BANK_OF_QUESTION, MessageItem.STRING_IS_EMPTY);
            return await Task.FromResult(result);
        }
    }
}
