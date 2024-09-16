using BankOfQuestionService.Answer.AnswerUpdate.Convertor;
using BankOfQuestionService.Answer.AnswerUpdate.Dto;
using BankOfQuestionService.Answer.AnswerUpdate.Validator;
using Core.Base.Command.Update;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Answer;
using Repository.Answer;

namespace BankOfQuestionService.Answer.AnswerUpdate.Command
{
    public class AnswerUpdateCommand(
        IAnswerRepository repository,
        IAnswerUpdateConvertor convertor,
        IAnswerUpdateValidator validator,
        ICodeBookRepository<CultureDbo> culture
        )
                : BaseUpdateCommand<AnswerDbo, IAnswerRepository, AnswerUpdateDto, IAnswerUpdateConvertor, IAnswerUpdateValidator>(repository, convertor, validator, culture),
            IAnswerUpdateService
    {
    }
}
