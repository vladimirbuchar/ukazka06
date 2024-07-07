﻿using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.BankOfQuestions;
using Model.Edu.Question;
using Repository.BankOfQuestionRepository;
using Repository.QuestionRepository;
using Services.BankOfQuestion.Convertor;
using Services.BankOfQuestion.Dto;
using Services.BankOfQuestion.Validator;
using System;
using System.Collections.Generic;

namespace Services.BankOfQuestion.Service
{
    public class BankOfQuestionService(
        IBankOfQuestionRepository bankOfQuestionRepository,
        IQuestionRepository questionRepository,
        IBankOfQuestionConvertor bankOfQuestionConvertor,
        IBankOfQuestionValidator validator
    )
        : BaseService<
            IBankOfQuestionRepository,
            BankOfQuestionDbo,
            IBankOfQuestionConvertor,
            IBankOfQuestionValidator,
            BankOfQuestionCreateDto,
            BankOfQuestionListDto,
            BankOfQuestionDetailDto,
            BankOfQuestionUpdateDto
        >(bankOfQuestionRepository, bankOfQuestionConvertor, validator),
            IBankOfQuestionService
    {
        private readonly IQuestionRepository _questionRepository = questionRepository;

        public override Result DeleteObject(Guid objectId, Guid userId)
        {
            HashSet<QuestionDbo> getQuestionsInBanks = _questionRepository.GetEntities(false, x => x.BankOfQuestionId == objectId);
            Guid organizationId = _repository.GetEntity(objectId).OrganizationId;
            Guid defaultBankOfQuestion = _repository.GetEntity(false, x => x.OrganizationId == organizationId && x.IsDefault).Id;
            foreach (QuestionDbo item in getQuestionsInBanks)
            {
                item.BankOfQuestionId = defaultBankOfQuestion;
                _ = _questionRepository.UpdateEntity(item, userId);
            }
            _repository.DeleteEntity(objectId, userId);
            return new Result();
        }
    }
}
