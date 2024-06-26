﻿using Core.Base.Repository.CodeBookRepository;
using Core.Constants;
using EduServices.Answer.Dto;
using Microsoft.Extensions.Configuration;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Answer;
using Model.Tables.Edu.TestQuestion;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Answer.Convertor
{
    public class AnswerConvertor(IConfiguration configuration, ICodeBookRepository<CultureDbo> codeBookService) : IAnswerConvertor
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly HashSet<CultureDbo> _cultureList = codeBookService.GetCodeBookItems();

        public AnswerDbo ConvertToBussinessEntity(AnswerCreateDto addAnswerDto, string culture)
        {
            AnswerDbo test = new() { IsTrueAnswer = addAnswerDto.IsTrueAnswer, TestQuestionId = addAnswerDto.QuestionId };
            test.TestQuestionAnswerTranslations = test.TestQuestionAnswerTranslations.PrepareTranslation(addAnswerDto.AnswerText, culture, _cultureList);
            return test;
        }

        public AnswerDbo ConvertToBussinessEntity(AnswerUpdateDto updateAnswerDto, AnswerDbo entity, string culture)
        {
            entity.IsTrueAnswer = updateAnswerDto.IsTrueAnswer;
            entity.TestQuestionAnswerTranslations = entity.TestQuestionAnswerTranslations.PrepareTranslation(updateAnswerDto.AnswerText, culture, _cultureList);
            return entity;
        }

        public HashSet<AnswerListDto> ConvertToWebModel(HashSet<AnswerDbo> getAnswersInQuestions, string culture)
        {
            return getAnswersInQuestions
                .Select(item => new AnswerListDto()
                {
                    Answer = item.TestQuestionAnswerTranslations.FindTranslation(culture)?.Answer,
                    Id = item.Id,
                    IsTrueAnswer = item.IsTrueAnswer,
                    FileId = item.AnswerFileRepository.FindTranslation(culture)?.Id,
                    FileName = item.AnswerFileRepository.FindTranslation(culture)?.OriginalFileName,
                    PreivewUrl =
                        item.AnswerFileRepository == null
                            ? ""
                            : string.Format(
                                "{0}{1}/{2}",
                                _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value,
                                item?.AnswerFileRepository?.FindTranslation(culture)?.Id,
                                item.AnswerFileRepository.FindTranslation(culture)?.FileName
                            )
                })
                .ToHashSet();
        }

        public AnswerDetailDto ConvertToWebModel(AnswerDbo answerDetail, string culture)
        {
            return new AnswerDetailDto()
            {
                Answer = answerDetail.TestQuestionAnswerTranslations.FindTranslation(culture)?.Answer,
                Id = answerDetail.Id,
                IsTrueAnswer = answerDetail.IsTrueAnswer,
                FileId = answerDetail.AnswerFileRepository?.FindTranslation(culture)?.Id,
                FileName = answerDetail.AnswerFileRepository?.FindTranslation(culture)?.FileName
            };
        }
    }
}
