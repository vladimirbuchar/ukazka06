using Core.Base.Service;
using EduRepository.BankOfQuestionRepository;
using EduRepository.QuestionRepository;
using EduServices.BankOfQuestion.Convertor;
using EduServices.BankOfQuestion.Dto;
using EduServices.BankOfQuestion.Validator;
using Model.Tables.Edu.BankOfQuestions;
using Model.Tables.Edu.TestQuestion;
using System;
using System.Collections.Generic;

namespace EduServices.BankOfQuestion.Service
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

        public override void DeleteObject(Guid objectId, Guid userId)
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
        }
    }
}
