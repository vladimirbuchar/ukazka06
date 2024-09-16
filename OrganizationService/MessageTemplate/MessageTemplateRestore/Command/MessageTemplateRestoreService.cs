using Core.Base.Command.Restore;
using Model.Edu.Message;
using Repository.MessageTemplate;

namespace OrganizationService.MessageTemplate.MessageTemplateRestore.Command
{
    public class MessageTemplateRestoreService : BaseRestoreCommand<MessageTemplateDbo, IMessageTemplateRepository>, IMessageTemplateRestoreService
    {
        public MessageTemplateRestoreService(IMessageTemplateRepository repository)
            : base(repository) { }
    }
}
