using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.BankOfQuestionRepository;
using EduRepository.QuestionRepository;
using EduServices.Question.Dto;
using Model.CodeBook;
using Model.Edu.Question;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Question.Validator
{
    public class QuestionValidator(
        IBankOfQuestionRepository bankOfQuestionRepository,
        IQuestionRepository repository,
        ICodeBookRepository<AnswerModeDbo> answerMode,
        ICodeBookRepository<QuestionModeDbo> questionMode
    ) : BaseValidator<QuestionDbo, IQuestionRepository, QuestionCreateDto, QuestionDetailDto, QuestionUpdateDto>(repository), IQuestionValidator
    {
        private readonly HashSet<AnswerModeDbo> _answerModes = answerMode.GetEntities(false);
        private readonly HashSet<QuestionModeDbo> _questionModes = questionMode.GetEntities(false);
        private readonly IBankOfQuestionRepository _bankOfQuestionRepository = bankOfQuestionRepository;

        public override Result<QuestionDetailDto> IsValid(QuestionCreateDto create)
        {
            Result<QuestionDetailDto> result = new();
            IsValidString(create.Question, result, Category.QUESTION, GlobalValue.STRING_IS_EMPTY);
            IsValidAnswerMode(create.AnswerModeId, result);
            IsValidQuestionMode(create.QuestionModeId, result);
            if (_bankOfQuestionRepository.GetEntity(create.BankOfQuestionId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.BANK_OF_QUESTION, GlobalValue.NOT_EXISTS));
            }
            return result;
        }

        public override Result<QuestionDetailDto> IsValid(QuestionUpdateDto update)
        {
            Result<QuestionDetailDto> result = new();
            IsValidString(update.Question, result, Category.QUESTION, GlobalValue.STRING_IS_EMPTY);
            IsValidAnswerMode(update.AnswerModeId, result);
            IsValidQuestionMode(update.QuestionModeId, result);
            return result;
        }

        private void IsValidAnswerMode(Guid answerModeId, Result result)
        {
            AnswerModeDbo answerMode = _answerModes.FirstOrDefault(x => x.Id == answerModeId);
            if (answerMode.SystemIdentificator == CodebookValue.CODEBOOK_SELECT_VALUE)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.QUESTION, Constants.SELECT_ANSWER_MODE));
            }
        }

        private void IsValidQuestionMode(Guid questionMode, Result result)
        {
            QuestionModeDbo qmode = _questionModes.FirstOrDefault(x => x.Id == questionMode);
            if (qmode.SystemIdentificator == CodebookValue.CODEBOOK_SELECT_VALUE)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.QUESTION, Constants.SELECT_QUESTION_MODE));
            }
        }
    }
}
