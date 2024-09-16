using BankOfQuestionService.Answer.AnswerCreate.Dto;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Answer;
using Model.Edu.Question;
using Repository.Answer;
using Repository.Question;

namespace BankOfQuestionService.Answer.AnswerCreate.Validator
{
    public class AnswerCreateValidator(
        ICodeBookRepository<AnswerModeDbo> answerModes,
        IAnswerRepository repository,
        IQuestionRepository questionRepository
        ) : BaseCreateValidator<AnswerDbo, IAnswerRepository, AnswerCreateDto>(repository), IAnswerCreateValidator
    {
        private readonly IQuestionRepository _questionRepository = questionRepository;
        private readonly ICodeBookRepository<AnswerModeDbo> _answerModes = answerModes;

        public override async Task<ResultInsert> IsValid(AnswerCreateDto create)
        {
            ResultInsert result = new();
            QuestionDbo testQuestion = await _questionRepository.GetEntity(create.QuestionId);
            if (testQuestion == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.QUESTION, MessageItem.NOT_EXISTS));
            }
            if (
                (await _answerModes.GetEntity(false, x => x.Id == testQuestion.AnswerModeId)).SystemIdentificator
                is AnswerMode.SELECT_MANY
                    or AnswerMode.SELECT_ONE
            )
            {
                IsValidString(create.AnswerText, result, MessageCategory.ANSWER, MessageItem.STRING_IS_EMPTY);
            }
            return result;
        }
    }
}
