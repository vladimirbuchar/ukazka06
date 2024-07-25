using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.BankOfQuestions;
using Repository.BankOfQuestionRepository;
using Repository.OrganizationRepository;
using Services.BankOfQuestion.Dto;
using System.Threading.Tasks;

namespace Services.BankOfQuestion.Validator
{
    public class BankOfQuestionValidator(IBankOfQuestionRepository repository, IOrganizationRepository organizationRepository)
        : BaseValidator<BankOfQuestionDbo, IBankOfQuestionRepository, BankOfQuestionCreateDto, BankOfQuestionDetailDto, BankOfQuestionUpdateDto>(
            repository
        ),
            IBankOfQuestionValidator
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override async Task<Result> IsValid(BankOfQuestionCreateDto create)
        {
            Result<BankOfQuestionDetailDto> result = new();
            IsValidString(create.Name, result, MessageCategory.BANK_OF_QUESTION, MessageItem.STRING_IS_EMPTY);
            if (await _organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.ORGANIZATION, MessageItem.NOT_EXISTS));
            }
            return result;
        }

        public override Task<Result<BankOfQuestionDetailDto>> IsValid(BankOfQuestionUpdateDto update)
        {
            Result<BankOfQuestionDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.BANK_OF_QUESTION, MessageItem.STRING_IS_EMPTY);
            return Task.FromResult(result);
        }
    }
}
