﻿using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Answer;
using Services.Answer.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Answer.Convertor
{
    public class AnswerConvertor(ICodeBookRepository<CultureDbo> codeBookRepository) : IAnswerConvertor
    {
        private readonly List<CultureDbo> _cultureList = codeBookRepository.GetEntities(false).Result;

        public Task<AnswerDbo> ConvertToBussinessEntity(AnswerCreateDto addAnswerDto, string culture)
        {
            AnswerDbo test = new() { IsTrueAnswer = addAnswerDto.IsTrueAnswer, TestQuestionId = addAnswerDto.QuestionId };
            test.TestQuestionAnswerTranslations = test.TestQuestionAnswerTranslations.PrepareTranslation(
                addAnswerDto.AnswerText,
                culture,
                _cultureList
            );
            return Task.FromResult(test);
        }

        public Task<AnswerDbo> ConvertToBussinessEntity(AnswerUpdateDto updateAnswerDto, AnswerDbo entity, string culture)
        {
            entity.IsTrueAnswer = updateAnswerDto.IsTrueAnswer;
            entity.TestQuestionAnswerTranslations = entity.TestQuestionAnswerTranslations.PrepareTranslation(
                updateAnswerDto.AnswerText,
                culture,
                _cultureList
            );
            return Task.FromResult(entity);
        }

        public Task<List<AnswerListDto>> ConvertToWebModel(List<AnswerDbo> getAnswersInQuestions, string culture)
        {
            return Task.FromResult(getAnswersInQuestions
                .Select(item => new AnswerListDto()
                {
                    Answer = item.TestQuestionAnswerTranslations.FindTranslation(culture)?.Answer,
                    Id = item.Id,
                    IsTrueAnswer = item.IsTrueAnswer
                })
                .ToList());
        }

        public Task<AnswerDetailDto> ConvertToWebModel(AnswerDbo answerDetail, string culture)
        {
            return Task.FromResult(new AnswerDetailDto()
            {
                Answer = answerDetail.TestQuestionAnswerTranslations.FindTranslation(culture)?.Answer,
                Id = answerDetail.Id,
                IsTrueAnswer = answerDetail.IsTrueAnswer,
                FileId = answerDetail.AnswerFileRepository?.FindTranslation(culture)?.Id,
                FileName = answerDetail.AnswerFileRepository?.FindTranslation(culture)?.FileName
            });
        }
    }
}
