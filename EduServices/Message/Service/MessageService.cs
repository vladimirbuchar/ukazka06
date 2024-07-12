using Core.Base.Service;
using Model.CodeBook;
using Model.Edu.Branch;
using Model.Edu.ClassRoom;
using Model.Edu.Message;
using Repository.MessageRepository;
using Services.Message.Convertor;
using Services.Message.Dto;
using Services.Message.Filter;
using Services.Message.Sort;
using Services.Message.Validator;
using System;
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
        protected override Expression<Func<MessageDbo, bool>> PrepareSqlFilter(MessageFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(MessageDbo), "message");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterString(filter.Reply, parameter, expression, nameof(MessageDbo.Reply));
            expression = FilterGuid(filter.SendMessageTypeId, parameter, expression, nameof(MessageDbo.SendMessageTypeId));
            expression = FilterTranslation<MessageTranslationDbo>(
                filter.Name,
                culture,
                parameter,
                expression,
                nameof(MessageTranslationDbo.Subject),
                nameof(MessageTranslationDbo.Culture),
                nameof(MessageDbo.SendMessageTranslations)
            );
            return Expression.Lambda<Func<MessageDbo, bool>>(expression, parameter);
        }

        protected override bool IsChanged(MessageDbo oldVersion, MessageUpdateDto newVersion, string culture)
        {
            return oldVersion.SendMessageTranslations.FindTranslation(culture).Subject != newVersion.Name
                || oldVersion.SendMessageTranslations.FindTranslation(culture).Html != newVersion.Html
                || oldVersion.Reply != newVersion.Reply
                || oldVersion.SendMessageTypeId != oldVersion.SendMessageTypeId;
        }

        protected override Expression<Func<MessageDbo, object>> PrepareSort(string columnName, string culture)
        {
            if (columnName == MessageSort.Name.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(MessageDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(MessageDbo.SendMessageTranslations));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(MessageTranslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(MessageTranslationDbo.Subject));
                Expression<Func<MessageDbo, object>> lambda = Expression.Lambda<Func<MessageDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return lambda;
            }
            else if (columnName == MessageSort.SendMessageType.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(MessageDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(MessageDbo.SendMessageType));
                MemberExpression nameProperty = Expression.Property(property, nameof(SendMessageTypeDbo.Name));
                Expression<Func<MessageDbo, object>> lambda = Expression.Lambda<Func<MessageDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return lambda;
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
