using Core.Base.Command.Restore;
using Model.Edu.Answer;
using Repository.Answer;

namespace BankOfQuestionService.Answer.AnswerRestore.Command
{
    public class AnswerRestoreCommand : BaseRestoreCommand<AnswerDbo, IAnswerRepository>, IAnswerRestoreCommand
    {
        public AnswerRestoreCommand(IAnswerRepository repository)
            : base(repository) { }
    }
}
