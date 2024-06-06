using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.BankOfQuestionRepository;
using EduRepository.OrganizationRepository;
using EduServices.BankOfQuestion.Dto;
using Model.Tables.Edu.BankOfQuestions;

namespace EduServices.BankOfQuestion.Validator
{
    public class BankOfQuestionValidator(IBankOfQuestionRepository repository, IOrganizationRepository organizationRepository)
        : BaseValidator<BankOfQuestionDbo, IBankOfQuestionRepository, BankOfQuestionCreateDto, BankOfQuestionDetailDto, BankOfQuestionUpdateDto>(repository),
            IBankOfQuestionValidator
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override Result<BankOfQuestionDetailDto> IsValid(BankOfQuestionCreateDto create)
        {
            Result<BankOfQuestionDetailDto> result = new();
            IsValidString(create.Name, result, ErrorCategory.BANK_OF_QUESTION, GlobalValue.STRING_IS_EMPTY);
            if (_organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.ORGANIZATION, GlobalValue.NOT_EXISTS));
            }
            return result;
        }

        public override Result<BankOfQuestionDetailDto> IsValid(BankOfQuestionUpdateDto update)
        {
            Result<BankOfQuestionDetailDto> result = new();
            IsValidString(update.Name, result, ErrorCategory.BANK_OF_QUESTION, GlobalValue.STRING_IS_EMPTY);
            return result;
        }
    }
}
