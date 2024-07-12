using System.Collections.Generic;
using System.Linq;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.BankOfQuestions;
using Model.Edu.Question;
using Services.Question.Dto;

namespace Services.Question.Convertor
{
    public class QuestionConvertor(ICodeBookRepository<CultureDbo> codeBookRepository) : IQuestionConvertor
    {
        private readonly List<CultureDbo> _cultureList = codeBookRepository.GetEntities(false).Result;

        public QuestionDbo ConvertToBussinessEntity(QuestionCreateDto addQuestionDto, string culture)
        {
            QuestionDbo question =
                new()
                {
                    AnswerModeId = addQuestionDto.AnswerModeId,
                    BankOfQuestionId = addQuestionDto.BankOfQuestionId,
                    QuestionModeId = addQuestionDto.QuestionModeId
                };
            question.TestQuestionTranslation = question.TestQuestionTranslation.PrepareTranslation(addQuestionDto.Question, culture, _cultureList);
            return question;
        }

        public QuestionDbo ConvertToBussinessEntity(QuestionUpdateDto updateQuestionDto, QuestionDbo entity, string culture)
        {
            entity.AnswerModeId = updateQuestionDto.AnswerModeId;
            entity.BankOfQuestionId = updateQuestionDto.BankOfQuestionId;
            entity.QuestionModeId = updateQuestionDto.QuestionModeId;
            entity.TestQuestionTranslation = entity.TestQuestionTranslation.PrepareTranslation(updateQuestionDto.Question, culture, _cultureList);
            return entity;
        }

        public List<QuestionListDto> ConvertToWebModel(List<QuestionDbo> getQuestionsInBanks, string culture)
        {
            return getQuestionsInBanks
                .Select(item => new QuestionListDto()
                {
                    AnswerModeId = item.AnswerModeId,
                    Id = item.Id,
                    Question = item.TestQuestionTranslation?.FindTranslation(culture)?.Question,
                    AnswerModeName = item.AnswerMode.Name,
                    QuestionModeId = item.QuestionModeId,
                    QuestionModeName = item.QuestionMode.Name
                })
                .ToList();
        }

        public QuestionDetailDto ConvertToWebModel(QuestionDbo getQuestionDetail, string culture)
        {
            return new QuestionDetailDto()
            {
                AnswerModeId = getQuestionDetail.AnswerModeId,
                Id = getQuestionDetail.Id,
                Question = getQuestionDetail.TestQuestionTranslation.FindTranslation(culture).Question,
                BankOfQuestionId = getQuestionDetail.BankOfQuestionId,
                QuestionModeId = getQuestionDetail.QuestionModeId,
                FileId = getQuestionDetail.QuestionFileRepositories.FindTranslation(culture)?.Id,
                OriginalFileName = getQuestionDetail.QuestionFileRepositories.FindTranslation(culture)?.OriginalFileName
            };
        }
    }
}
