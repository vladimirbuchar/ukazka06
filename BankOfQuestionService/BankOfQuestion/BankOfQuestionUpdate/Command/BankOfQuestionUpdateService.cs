using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Convertor;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Dto;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Validator;
using Core.Base.Command.Update;
using Core.Base.Repository.CodeBookRepository;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.BankOfQuestions;
using Repository.BankOfQuestion;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Command
{
    public class BankOfQuestionUpdateService
        : BaseUpdateCommand<
            BankOfQuestionDbo,
            IBankOfQuestionRepository,
            BankOfQuestionUpdateDto,
            IBankOfQuestionUpdateConvertor,
            IBankOfQuestionUpdateValidator

        >,
            IBankOfQuestionUpdateService
    {
        public BankOfQuestionUpdateService(
            IBankOfQuestionRepository repository,
            IBankOfQuestionUpdateConvertor convertor,
            IBankOfQuestionUpdateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture) { }

        public override async Task<Result> Execute(BankOfQuestionUpdateDto update, Guid userId, string culture, Result? result = null)
        {
            result ??= new Result();
            Guid organizationId = (await _repository.GetEntity(update.Id)).OrganizationId;
            Guid defaultBankOfQuestionId = (await _repository.GetEntity(false, x => x.OrganizationId == organizationId && x.IsDefault)).Id;
            if (update.Id == defaultBankOfQuestionId)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.BANK_OF_QUESTION, MessageItem.CAN_NOT_EDIT));
                return result;
            }
            return await base.Execute(update, userId, culture, result);
        }
    }
}
