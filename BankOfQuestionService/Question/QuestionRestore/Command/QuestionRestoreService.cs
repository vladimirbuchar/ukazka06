using Core.Base.Command.Restore;
using Model.Edu.Question;
using Repository.Question;

namespace BankOfQuestionService.Question.QuestionRestore.Command
{
    public class QuestionRestoreService : BaseRestoreCommand<QuestionDbo, IQuestionRepository>, IQuestionRestoreService
    {
        public QuestionRestoreService(IQuestionRepository repository)
            : base(repository) { }
    }
}
