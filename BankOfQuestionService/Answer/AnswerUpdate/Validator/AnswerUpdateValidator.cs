using BankOfQuestionService.Answer.AnswerDetail.Dto;
using BankOfQuestionService.Answer.AnswerUpdate.Dto;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Answer;
using Model.Edu.Question;
using Repository.Answer;

namespace BankOfQuestionService.Answer.AnswerUpdate.Validator
{
    public class AnswerUpdateValidator : BaseUpdateValidator<AnswerDbo, IAnswerRepository, AnswerUpdateDto>, IAnswerUpdateValidator
    {
        private readonly ICodeBookRepository<AnswerModeDbo> _answerModes;

        public AnswerUpdateValidator(IAnswerRepository repository, ICodeBookRepository<AnswerModeDbo> answerModes)
            : base(repository)
        {
            _answerModes = answerModes;
        }

        public override async Task<Result> IsValid(AnswerUpdateDto update)
        {
            Result<AnswerDetailDto> result = new();
            AnswerDbo answer = await _repository.GetEntity(update.Id);
            QuestionDbo question = answer.Question;
            if (
                (await _answerModes.GetEntity(false, x => x.Id == question.AnswerModeId)).SystemIdentificator
                is AnswerMode.SELECT_MANY
                    or AnswerMode.SELECT_ONE
            )
            {
                IsValidString(update.AnswerText, result, MessageCategory.ANSWER, MessageItem.STRING_IS_EMPTY);
            }
            return result;
        }
    }
}
