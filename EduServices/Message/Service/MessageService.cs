using Core.Base.Service;
using Model.Edu.Message;
using Repository.MessageRepository;
using Services.Message.Convertor;
using Services.Message.Dto;
using Services.Message.Filter;
using Services.Message.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Message.Service
{
    public class MessageService(IMessageRepository sendMessageRepository, IMessageConvertor convertor, IMessageValidator validator)
        : BaseService<
            IMessageRepository,
            MessageDbo,
            IMessageConvertor,
            IMessageValidator,
            MessageCreateDto,
            MessageListDto,
            MessageDetailDto,
            MessageUpdateDto,
            MessageFilter
        >(sendMessageRepository, convertor, validator),
            IMessageService
    {
        protected override List<MessageDbo> PrepareMemoryFilter(List<MessageDbo> entities, MessageFilter filter, string culture)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                entities = entities
                    .Where(x => x.SendMessageTranslations.Any(y => y.Subject.Contains(filter.Name) && y.Culture.SystemIdentificator == culture))
                    .ToList();
            }

            if (filter.SendMessageTypeId.Count > 0)
            {
                entities = entities.Where(x => filter.SendMessageTypeId.Contains(x.SendMessageTypeId)).ToList();
            }
            return entities;
        }

        protected override Expression<Func<MessageDbo, bool>> PrepareSqlFilter(MessageFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(MessageDbo), "message");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterString(filter.Reply, parameter, expression, nameof(MessageDbo.Reply));
            return Expression.Lambda<Func<MessageDbo, bool>>(expression, parameter);
        }

        protected override bool IsChanged(MessageDbo oldVersion, MessageUpdateDto newVersion, string culture)
        {
            return oldVersion.SendMessageTranslations.FindTranslation(culture).Subject != newVersion.Name
                || oldVersion.SendMessageTranslations.FindTranslation(culture).Html != newVersion.Html
                || oldVersion.Reply != newVersion.Reply
                || oldVersion.SendMessageTypeId != oldVersion.SendMessageTypeId;
        }
    }
}
