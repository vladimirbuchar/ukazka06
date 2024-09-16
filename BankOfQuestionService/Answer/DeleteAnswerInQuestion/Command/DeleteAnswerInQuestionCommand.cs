using Core.Base.Command.MultipleDelete;
using Model.Edu.Answer;
using Repository.Answer;
using Repository.Question;

namespace BankOfQuestionService.Answer.DeleteAnswerInQuestion.Command
{
    public class DeleteAnswerInQuestionCommand : BaseMultipleDeleteCommand<AnswerDbo, IAnswerRepository>, IDeleteAnswerInQuestionCommnad
    {
        private readonly IQuestionRepository _questionRepository;

        public DeleteAnswerInQuestionCommand(IAnswerRepository repository, IQuestionRepository questionRepository)
            : base(repository)
        {
            _questionRepository = questionRepository;
        }

        public override Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return _questionRepository.GetOrganizationId(objectId);
        }
    }
}
