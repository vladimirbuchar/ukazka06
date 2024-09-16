using BankOfQuestionService.Answer.AnswerCreate.Convertor;
using BankOfQuestionService.Answer.AnswerCreate.Dto;
using BankOfQuestionService.Answer.AnswerCreate.Validator;
using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Answer;
using Repository.Answer;
using Repository.Question;

namespace BankOfQuestionService.Answer.AnswerCreate.Command
{
    public class AnswerCreateCommand
        : BaseCreateCommand<AnswerDbo, IAnswerRepository, AnswerCreateDto, IAnswerCreateConvertor, IAnswerCreateValidator>,
            IAnswerCreateCommand
    {
        private readonly IQuestionRepository _questionRepository;

        public AnswerCreateCommand(
            IQuestionRepository questionRepository,
            IAnswerRepository repository,
            IAnswerCreateConvertor convertor,
            IAnswerCreateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture)
        {
            _questionRepository = questionRepository;
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _questionRepository.GetOrganizationId(objectId);
        }
    }
}
