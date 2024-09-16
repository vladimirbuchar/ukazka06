using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateCreate.Convertor;
using OrganizationService.MessageTemplate.MessageTemplateCreate.Dto;
using OrganizationService.MessageTemplate.MessageTemplateCreate.Validator;
using Repository.MessageTemplate;

namespace OrganizationService.MessageTemplate.MessageTemplateCreate.Command
{
    public class MessageTemplateCreateService
        : BaseCreateCommand<MessageTemplateDbo, IMessageTemplateRepository, MessageCreateDto, IMessageTemplateCreateConvertor, IMessageTemplateCreateValidator>,
            IMessageTemplateCreateService
    {
        public MessageTemplateCreateService(
            IMessageTemplateRepository repository,
            IMessageTemplateCreateConvertor convertor,
            IMessageTemplateCreateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture) { }
    }
}
