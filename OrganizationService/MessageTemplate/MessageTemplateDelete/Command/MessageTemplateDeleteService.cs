using Core.Base.Command.Delete;
using Model.Edu.Message;
using Repository.MessageTemplate;

namespace OrganizationService.MessageTemplate.MessageTemplateDelete.Command
{
    public class MessageTemplateDeleteService : BaseDeleteCommand<MessageTemplateDbo, IMessageTemplateRepository>, IMessageTemplateDeleteService
    {
        public MessageTemplateDeleteService(IMessageTemplateRepository repository)
            : base(repository) { }
    }
}
