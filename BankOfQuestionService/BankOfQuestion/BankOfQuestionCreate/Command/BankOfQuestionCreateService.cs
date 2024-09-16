using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Convertor;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Dto;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Validator;
using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.BankOfQuestions;
using Repository.BankOfQuestion;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Command
{
    public class BankOfQuestionCreateService(
        IBankOfQuestionRepository repository,
        IBankOfQuestionCreateConvertor convertor,
        IBankOfQuestionCreateValidator validator,
        ICodeBookRepository<CultureDbo> culture
        )
                : BaseCreateCommand<
            BankOfQuestionDbo,
            IBankOfQuestionRepository,
            BankOfQuestionCreateDto,
            IBankOfQuestionCreateConvertor,
            IBankOfQuestionCreateValidator
        >(repository, convertor, validator, culture),
            IBankOfQuestionCreateService
    {
    }
}
