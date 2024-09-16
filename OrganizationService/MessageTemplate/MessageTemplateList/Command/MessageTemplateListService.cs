using Core.Base.Command.List;
using Core.Base.Sort;
using Model.CodeBook;
using Model.Edu.Message;
using OrganizationService.MessageTemplate.MessageTemplateList.Convertor;
using OrganizationService.MessageTemplate.MessageTemplateList.Dto;
using OrganizationService.MessageTemplate.MessageTemplateList.Filter;
using OrganizationService.MessageTemplate.MessageTemplateList.Sort;
using Repository.MessageTemplate;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace OrganizationService.MessageTemplate.MessageTemplateList.Command
{
    public class MessageTemplateListService
        : BaseListCommand<MessageTemplateDbo, IMessageTemplateRepository, MessageListDto, IMessageTemplateListConvertor, MessageFilter>,
            IMessageTemplateListService
    {
        public MessageTemplateListService(IMessageTemplateRepository repository, IMessageTemplateListConvertor convertor)
            : base(repository, convertor) { }

        protected override List<BaseSort<MessageTemplateDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            if (columnName == MessageSort.Name.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(MessageTemplateDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(MessageTemplateDbo.SendMessageTranslations));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(MessageTemplateTranslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(MessageTemplateTranslationDbo.Subject));
                Expression<Func<MessageTemplateDbo, object>> lambda = Expression.Lambda<Func<MessageTemplateDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<MessageTemplateDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            else if (columnName == MessageSort.SendMessageType.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(MessageTemplateDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(MessageTemplateDbo.SendMessageType));
                MemberExpression nameProperty = Expression.Property(property, nameof(MessageTemplateTypeDbo.Name));
                Expression<Func<MessageTemplateDbo, object>> lambda = Expression.Lambda<Func<MessageTemplateDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<MessageTemplateDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return base.PrepareSort(columnName, culture);
        }

        protected override Expression<Func<MessageTemplateDbo, bool>> PrepareSqlFilter(MessageFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(MessageTemplateDbo), "message");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterString(filter.Reply, parameter, expression, nameof(MessageTemplateDbo.Reply));
            expression = FilterGuid(filter.SendMessageTypeId, parameter, expression, nameof(MessageTemplateDbo.SendMessageTypeId));
            expression = FilterTranslation<MessageTemplateTranslationDbo>(
                filter.Name,
                culture,
                parameter,
                expression,
                nameof(MessageTemplateTranslationDbo.Subject),
                nameof(MessageTemplateTranslationDbo.Culture),
                nameof(MessageTemplateDbo.SendMessageTranslations)
            );
            return Expression.Lambda<Func<MessageTemplateDbo, bool>>(expression, parameter);
        }
    }
}
