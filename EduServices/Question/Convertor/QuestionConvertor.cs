using System.Collections.Generic;
using System.Linq;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.BankOfQuestions;
using Model.Edu.Question;
using Services.Question.Dto;

namespace Services.Question.Convertor
{
    public class QuestionConvertor(ICodeBookRepository<CultureDbo> codeBookService) : IQuestionConvertor
    {
        private readonly HashSet<CultureDbo> _cultureList = codeBookService.GetEntities(false);

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

        public HashSet<QuestionListDto> ConvertToWebModel(HashSet<QuestionDbo> getQuestionsInBanks, string culture)
        {
            return getQuestionsInBanks
                .Select(item => new QuestionListDto()
                {
                    AnswerMode = item.AnswerModeId,
                    Id = item.Id,
                    Question = item.TestQuestionTranslation?.FindTranslation(culture)?.Question,
                    BankOfQuestionName = item.BankOfQuestion.BankOfQuestionsTranslations?.FindTranslation(culture)?.Name,
                    BankOfQuestionId = item.BankOfQuestionId
                })
                .ToHashSet();
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
                FileId = getQuestionDetail.QuestionFileRepositories.FirstOrDefault(x => x.QuestionId == getQuestionDetail.Id && x.Culture.SystemIdentificator == culture && x.IsDeleted == false).Id,
                OriginalFileName = getQuestionDetail
                    .QuestionFileRepositories.FirstOrDefault(x => x.QuestionId == getQuestionDetail.Id && x.Culture.SystemIdentificator == culture && x.IsDeleted == false)
                    .OriginalFileName
            };
        }
    }
}
