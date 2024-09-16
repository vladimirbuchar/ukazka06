using BankOfQuestionService.Question.QuestionCreate.Convertor;
using BankOfQuestionService.Question.QuestionCreate.Dto;
using BankOfQuestionService.Question.QuestionCreate.Validator;
using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Question;
using Repository.BankOfQuestion;
using Repository.Question;

namespace BankOfQuestionService.Question.QuestionCreate.Command
{
    public class QuestionCreateService
        : BaseCreateCommand<QuestionDbo, IQuestionRepository, QuestionCreateDto, IQuestionCreateConvertor, IQuestionCreateValidator>,
            IQuestionCreateService
    {
        private readonly IBankOfQuestionRepository _bankOfQuestionRepository;

        public QuestionCreateService(
            IBankOfQuestionRepository bankOfQuestionRepository,
            IQuestionRepository repository,
            IQuestionCreateConvertor convertor,
            IQuestionCreateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture)
        {
            _bankOfQuestionRepository = bankOfQuestionRepository;
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _bankOfQuestionRepository.GetOrganizationId(objectId);
        }
    }
}
