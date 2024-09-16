using BankOfQuestionService.Question.QuestionUpdate.Convertor;
using BankOfQuestionService.Question.QuestionUpdate.Dto;
using BankOfQuestionService.Question.QuestionUpdate.Validator;
using Core.Base.Command.Update;
using Model.Edu.Question;
using Repository.Question;

namespace BankOfQuestionService.Question.QuestionUpdate.Command
{
    public class QuestionUpdateService
        : BaseUpdateCommand<QuestionDbo, IQuestionRepository, QuestionUpdateDto, IQuestionUpdateConvertor, IQuestionUpdateValidator>,
            IQuestionUpdateService
    {
        public QuestionUpdateService(IQuestionRepository repository, IQuestionUpdateConvertor convertor, IQuestionUpdateValidator validator)
            : base(repository, convertor, validator) { }
    }
}
