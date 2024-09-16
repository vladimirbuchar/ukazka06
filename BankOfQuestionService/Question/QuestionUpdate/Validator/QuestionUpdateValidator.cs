using BankOfQuestionService.Question.QuestionDetail.Dto;
using BankOfQuestionService.Question.QuestionUpdate.Dto;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Question;
using Repository.Question;

namespace BankOfQuestionService.Question.QuestionUpdate.Validator
{
    public class QuestionUpdateValidator : BaseUpdateValidator<QuestionDbo, IQuestionRepository, QuestionUpdateDto>, IQuestionUpdateValidator
    {
        private readonly ICodeBookRepository<AnswerModeDbo> _answerModes;
        private readonly ICodeBookRepository<QuestionModeDbo> _questionModes;

        public QuestionUpdateValidator(
            ICodeBookRepository<QuestionModeDbo> questionModes,
            IQuestionRepository repository,
            ICodeBookRepository<AnswerModeDbo> answerModes
        )
            : base(repository)
        {
            _answerModes = answerModes;
            _questionModes = questionModes;
        }

        public override async Task<Result> IsValid(QuestionUpdateDto update)
        {
            Result<QuestionDetailDto> result = new();
            IsValidString(update.Question, result, MessageCategory.QUESTION, MessageItem.STRING_IS_EMPTY);
            await CodeBookValueExist(
                _answerModes,
                x => x.Id == update.AnswerModeId,
                result,
                MessageCategory.QUESTION,
                Constants.SELECT_ANSWER_MODE
            );
            await CodeBookValueExist(
                _questionModes,
                x => x.Id == update.QuestionModeId,
                result,
                MessageCategory.QUESTION,
                Constants.SELECT_QUESTION_MODE
            );
            return await Task.FromResult(result);
        }
    }
}
