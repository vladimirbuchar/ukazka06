using BankOfQuestionService.Answer.AnswerList.Convertor;
using BankOfQuestionService.Answer.AnswerList.Dto;
using BankOfQuestionService.Answer.AnswerList.Filter;
using BankOfQuestionService.Answer.AnswerList.Sort;
using Core.Base.Command.List;
using Core.Base.Sort;
using Model.Edu.Answer;
using Repository.Answer;
using Repository.Question;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace BankOfQuestionService.Answer.AnswerList.Command
{
    public class AnswerListCommand
        : BaseListCommand<AnswerDbo, IAnswerRepository, AnswerListDto, IAnswerListConvertor, AnswerFilter>,
            IAnswerListCommand
    {
        private readonly IQuestionRepository _questionRepository;

        public AnswerListCommand(IQuestionRepository questionRepository, IAnswerRepository repository, IAnswerListConvertor convertor)
            : base(repository, convertor)
        {
            _questionRepository = questionRepository;
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _questionRepository.GetOrganizationId(objectId);
        }

        protected override Expression<Func<AnswerDbo, bool>> PrepareSqlFilter(AnswerFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(AnswerDbo), "answer");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterBool(filter.IsTrueAnswer, parameter, expression, nameof(AnswerDbo.IsTrueAnswer));
            expression = FilterTranslation<AnswerTanslationDbo>(
                filter.Answer,
                culture,
                parameter,
                expression,
                nameof(AnswerTanslationDbo.Answer),
                nameof(AnswerTanslationDbo.Culture),
                nameof(AnswerDbo.TestQuestionAnswerTranslations)
            );
            return Expression.Lambda<Func<AnswerDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<AnswerDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            if (columnName == AnswerSort.Answer.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(AnswerDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(AnswerDbo.TestQuestionAnswerTranslations));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    [typeof(AnswerTanslationDbo)],
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(AnswerTanslationDbo.Answer));
                Expression<Func<AnswerDbo, object>> lambda = Expression.Lambda<Func<AnswerDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<AnswerDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }

            return base.PrepareSort(columnName, culture);
        }
    }
}
