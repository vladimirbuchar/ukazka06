using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Question;
using Repository.BankOfQuestionRepository;
using Repository.QuestionRepository;
using Services.Question.Dto;
using System.Threading.Tasks;

namespace Services.Question.Validator
{
    public class QuestionValidator(
        IBankOfQuestionRepository bankOfQuestionRepository,
        IQuestionRepository repository,
        ICodeBookRepository<AnswerModeDbo> answerMode,
        ICodeBookRepository<QuestionModeDbo> questionMode
    ) : BaseValidator<QuestionDbo, IQuestionRepository, QuestionCreateDto, QuestionDetailDto, QuestionUpdateDto>(repository), IQuestionValidator
    {
        private readonly ICodeBookRepository<AnswerModeDbo> _answerModes = answerMode;
        private readonly ICodeBookRepository<QuestionModeDbo> _questionModes = questionMode;
        private readonly IBankOfQuestionRepository _bankOfQuestionRepository = bankOfQuestionRepository;

        public override async Task<Result> IsValid(QuestionCreateDto create)
        {
            Result<QuestionDetailDto> result = new();
            IsValidString(create.Question, result, MessageCategory.QUESTION, MessageItem.STRING_IS_EMPTY);
            await CodeBookValueExist<AnswerModeDbo>(_answerModes, x => x.Id == create.AnswerModeId, result, MessageCategory.QUESTION, Constants.SELECT_ANSWER_MODE);
            await CodeBookValueExist<QuestionModeDbo>(_questionModes, x => x.Id == create.QuestionModeId, result, MessageCategory.QUESTION, Constants.SELECT_QUESTION_MODE);
            if (await _bankOfQuestionRepository.GetEntity(create.BankOfQuestionId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.BANK_OF_QUESTION, MessageItem.NOT_EXISTS));
            }
            return result;
        }

        public override async Task<Result<QuestionDetailDto>> IsValid(QuestionUpdateDto update)
        {
            Result<QuestionDetailDto> result = new();
            IsValidString(update.Question, result, MessageCategory.QUESTION, MessageItem.STRING_IS_EMPTY);
            await CodeBookValueExist<AnswerModeDbo>(_answerModes, x => x.Id == update.AnswerModeId, result, MessageCategory.QUESTION, Constants.SELECT_ANSWER_MODE);
            await CodeBookValueExist<QuestionModeDbo>(_questionModes, x => x.Id == update.QuestionModeId, result, MessageCategory.QUESTION, Constants.SELECT_QUESTION_MODE);
            return await Task.FromResult(result);
        }
    }
}
