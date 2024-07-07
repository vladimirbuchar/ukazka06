using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.BankOfQuestions;
using Services.BankOfQuestion.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Services.BankOfQuestion.Convertor
{
    public class BankOfQuestionConvertor(ICodeBookRepository<CultureDbo> codeBookService) : IBankOfQuestionConvertor
    {
        private readonly HashSet<CultureDbo> _cultureList = codeBookService.GetEntities(false);

        public BankOfQuestionDbo ConvertToBussinessEntity(BankOfQuestionCreateDto addBankOfQuestionDto, string culture)
        {
            BankOfQuestionDbo bankOfQuestion = new() { OrganizationId = addBankOfQuestionDto.OrganizationId, IsDefault = false };
            bankOfQuestion.BankOfQuestionsTranslations = bankOfQuestion.BankOfQuestionsTranslations.PrepareTranslation(
                addBankOfQuestionDto.Name,
                culture,
                _cultureList
            );
            return bankOfQuestion;
        }

        public BankOfQuestionDbo ConvertToBussinessEntity(BankOfQuestionUpdateDto update, BankOfQuestionDbo entity, string culture)
        {
            entity.BankOfQuestionsTranslations = entity.BankOfQuestionsTranslations.PrepareTranslation(update.Name, culture, _cultureList);
            return entity;
        }

        public HashSet<BankOfQuestionListDto> ConvertToWebModel(HashSet<BankOfQuestionDbo> getBankOfQuestionInOrganizations, string culture)
        {
            return getBankOfQuestionInOrganizations
                .Select(item => new BankOfQuestionListDto()
                {
                    Name = item.BankOfQuestionsTranslations.FindTranslation(culture).Name,
                    Id = item.Id,
                    IsDefault = item.IsDefault
                })
                .ToHashSet();
        }

        public BankOfQuestionDetailDto ConvertToWebModel(BankOfQuestionDbo getBankOfQuestionDetail, string culture)
        {
            return new BankOfQuestionDetailDto()
            {
                Name = getBankOfQuestionDetail.BankOfQuestionsTranslations.FindTranslation(culture).Name,
                Id = getBankOfQuestionDetail.Id,
                IsDefault = getBankOfQuestionDetail.IsDefault
            };
        }
    }
}
