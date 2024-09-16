using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Dto;
using Model.Edu.BankOfQuestions;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Convertor
{
    public class BankOfQuestionCreateConvertor : IBankOfQuestionCreateConvertor
    {
        public Task<BankOfQuestionDbo> ConvertToBussinessEntity(BankOfQuestionCreateDto create, string culture)
        {
            BankOfQuestionDbo bankOfQuestion = new() { OrganizationId = create.OrganizationId, IsDefault = create.IsDefault };
            bankOfQuestion.BankOfQuestionsTranslations = bankOfQuestion.BankOfQuestionsTranslations.PrepareTranslation(create.Name, create.CultureId);
            return Task.FromResult(bankOfQuestion);
        }
    }
}
