using Core.Base.Command.Delete;
using Model.Edu.Answer;
using Repository.Answer;

namespace BankOfQuestionService.Answer.AnswerDelete.Command
{
    public class AnswerDeleteCommand(IAnswerRepository repository) : BaseDeleteCommand<AnswerDbo, IAnswerRepository>(repository), IAnswerDeleteCommand
    {
    }
}
