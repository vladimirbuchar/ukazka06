using BankOfQuestionService.Question.QuestionCreate.Dto;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Question;
using Repository.BankOfQuestion;
using Repository.Question;

namespace BankOfQuestionService.Question.QuestionCreate.Validator
{
    public class QuestionCreateValidator : BaseCreateValidator<QuestionDbo, IQuestionRepository, QuestionCreateDto>, IQuestionCreateValidator
    {
        private readonly ICodeBookRepository<AnswerModeDbo> _answerModes;
        private readonly ICodeBookRepository<QuestionModeDbo> _questionModes;
        private readonly IBankOfQuestionRepository _bankOfQuestionRepository;

        public QuestionCreateValidator(
            IBankOfQuestionRepository bankOfQuestionRepository,
            ICodeBookRepository<QuestionModeDbo> questionModes,
            IQuestionRepository repository,
            ICodeBookRepository<AnswerModeDbo> answerModes
        )
            : base(repository)
        {
            _answerModes = answerModes;
            _questionModes = questionModes;
            _bankOfQuestionRepository = bankOfQuestionRepository;
        }

        public override async Task<ResultInsert> IsValid(QuestionCreateDto create)
        {
            ResultInsert result = new();
            IsValidString(create.Question, result, MessageCategory.QUESTION, MessageItem.STRING_IS_EMPTY);
            await CodeBookValueExist(
                _answerModes,
                x => x.Id == create.AnswerModeId,
                result,
                MessageCategory.QUESTION,
                Constants.SELECT_ANSWER_MODE
            );
            await CodeBookValueExist(
                _questionModes,
                x => x.Id == create.QuestionModeId,
                result,
                MessageCategory.QUESTION,
                Constants.SELECT_QUESTION_MODE
            );
            if (await _bankOfQuestionRepository.GetEntity(create.BankOfQuestionId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.BANK_OF_QUESTION, MessageItem.NOT_EXISTS));
            }
            return result;
        }
    }
}
