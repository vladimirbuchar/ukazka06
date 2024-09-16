using Core.Base.Command.Delete;
using Model.Edu.Question;
using Repository.Question;

namespace BankOfQuestionService.Question.QuestionDelete.Command
{
    public class QuestionDeleteService : BaseDeleteCommand<QuestionDbo, IQuestionRepository>, IQuestionDeleteService
    {
        public QuestionDeleteService(IQuestionRepository repository)
            : base(repository) { }
    }
}
