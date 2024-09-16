using Core.Base.Command.Restore;
using Model.Edu.BankOfQuestions;
using Repository.BankOfQuestion;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionRestore.Command
{
    public class BankOfQuestionRestoreService : BaseRestoreCommand<BankOfQuestionDbo, IBankOfQuestionRepository>, IBankOfQuestionRestoreService
    {
        public BankOfQuestionRestoreService(IBankOfQuestionRepository repository)
            : base(repository) { }
    }
}
