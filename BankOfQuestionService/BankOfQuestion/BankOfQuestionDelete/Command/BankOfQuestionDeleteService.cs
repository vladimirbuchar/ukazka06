using Core.Base.Command.Delete;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.BankOfQuestions;
using Model.Edu.Question;
using Repository.BankOfQuestion;
using Repository.Question;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionDelete.Command
{
    public class BankOfQuestionDeleteService : BaseDeleteCommand<BankOfQuestionDbo, IBankOfQuestionRepository>, IBankOfQuestionDeleteService
    {
        private readonly IQuestionRepository _questionRepository;

        public BankOfQuestionDeleteService(IQuestionRepository questionRepository, IBankOfQuestionRepository repository)
            : base(repository)
        {
            _questionRepository = questionRepository;
        }

        public override async Task<Result> Execute(Guid objectId, Guid userId)
        {
            Result result = new();
            Guid organizationId = (await _repository.GetEntity(objectId)).OrganizationId;
            Guid defaultBankOfQuestionId = (await _repository.GetEntity(false, x => x.OrganizationId == organizationId && x.IsDefault)).Id;
            if (objectId == defaultBankOfQuestionId)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.BANK_OF_QUESTION, MessageItem.CAN_NOT_DELETE));
                return result;
            }
            List<QuestionDbo> getQuestionsInBanks = await _questionRepository.GetEntities(false, x => x.BankOfQuestionId == objectId);
            foreach (QuestionDbo item in getQuestionsInBanks)
            {
                item.BankOfQuestionId = defaultBankOfQuestionId;
                _ = await _questionRepository.UpdateEntity(item, userId);
            }
            await _repository.DeleteEntity(objectId, userId);
            return result;
        }
    }
}
