using Core.Base.Command.Update;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateUpdate.Convertor;
using OrganizationService.MessageTemplate.MessageTemplateUpdate.Dto;
using OrganizationService.MessageTemplate.MessageTemplateUpdate.Validator;
using Repository.MessageTemplate;

namespace OrganizationService.MessageTemplate.MessageTemplateUpdate.Command
{
    public class MessageTemplateUpdateService
        : BaseUpdateCommand<MessageTemplateDbo, IMessageTemplateRepository, MessageUpdateDto, IMessageTemplateUpdateConvertor, IMessageTemplateUpdateValidator>,
            IMessageTemplateUpdateService
    {
        public MessageTemplateUpdateService(
            IMessageTemplateRepository repository,
            IMessageTemplateUpdateConvertor convertor,
            IMessageTemplateUpdateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture) { }

        protected override bool IsChanged(MessageTemplateDbo oldVersion, MessageUpdateDto newVersion, string culture)
        {
            return oldVersion.SendMessageTranslations.FindTranslation([culture]).Subject != newVersion.Name
                || oldVersion.SendMessageTranslations.FindTranslation([culture]).Html != newVersion.Html
                || oldVersion.Reply != newVersion.Reply
                || oldVersion.SendMessageTypeId != oldVersion.SendMessageTypeId;
        }
    }
}
