using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Dto;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.BankOfQuestions;
using Repository.BankOfQuestion;
using Repository.Organization;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Validator
{
    public class BankOfQuestionCreateValidator
        : BaseCreateValidator<BankOfQuestionDbo, IBankOfQuestionRepository, BankOfQuestionCreateDto>,
            IBankOfQuestionCreateValidator
    {
        private readonly IOrganizationRepository _organizationRepository;

        public BankOfQuestionCreateValidator(IBankOfQuestionRepository repository, IOrganizationRepository organizationRepository)
            : base(repository)
        {
            _organizationRepository = organizationRepository;
        }

        public override async Task<ResultInsert> IsValid(BankOfQuestionCreateDto create)
        {
            ResultInsert result = new();
            IsValidString(create.Name, result, MessageCategory.BANK_OF_QUESTION, MessageItem.STRING_IS_EMPTY);
            if (await _organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            return result;
        }
    }
}
