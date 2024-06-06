using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.AnswerRepository;
using EduRepository.QuestionRepository;
using EduServices.Answer.Dto;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Answer;
using Model.Tables.Edu.TestQuestion;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Answer.Validator
{
    public class AnswerValidator(IQuestionRepository questionRepository, IAnswerRepository repository, ICodeBookRepository<AnswerModeDbo> codeBookRepository)
        : BaseValidator<AnswerDbo, IAnswerRepository, AnswerCreateDto, AnswerDetailDto, AnswerUpdateDto>(repository),
            IAnswerValidator
    {
        private readonly HashSet<AnswerModeDbo> _answerModes = codeBookRepository.GetCodeBookItems();
        private readonly IQuestionRepository _questionRepository = questionRepository;

        public override Result<AnswerDetailDto> IsValid(AnswerCreateDto create)
        {
            Result<AnswerDetailDto> result = new();
            QuestionDbo testQuestion = _questionRepository.GetEntity(create.QuestionId);
            if (testQuestion == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.QUESTION, GlobalValue.NOT_EXISTS));
            }
            if (_answerModes.FirstOrDefault(x => x.Id == testQuestion.AnswerModeId).SystemIdentificator is AnswerMode.SELECT_MANY or AnswerMode.SELECT_ONE)
            {
                IsValidString(create.AnswerText, result, ErrorCategory.ANSWER, GlobalValue.STRING_IS_EMPTY);
            }
            return result;
        }

        public override Result<AnswerDetailDto> IsValid(AnswerUpdateDto update)
        {
            Result<AnswerDetailDto> result = new();
            AnswerDbo answer = _repository.GetEntity(update.Id);
            QuestionDbo question = answer.TestQuestion;
            if (_answerModes.FirstOrDefault(x => x.Id == question.AnswerModeId).SystemIdentificator is AnswerMode.SELECT_MANY or AnswerMode.SELECT_ONE)
            {
                IsValidString(update.AnswerText, result, ErrorCategory.ANSWER, GlobalValue.STRING_IS_EMPTY);
            }
            return result;
        }
    }
}
