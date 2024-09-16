using BankOfQuestionService.Question.QuestionList.Convertor;
using BankOfQuestionService.Question.QuestionList.Dto;
using BankOfQuestionService.Question.QuestionList.Filter;
using BankOfQuestionService.Question.QuestionList.Sort;
using Core.Base.Command.List;
using Core.Base.Sort;
using Model.CodeBook;
using Model.Edu.Question;
using Repository.BankOfQuestion;
using Repository.Question;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace BankOfQuestionService.Question.QuestionList.Command
{
    public class QuestionListService
        : BaseListCommand<QuestionDbo, IQuestionRepository, QuestionListDto, IQuestionListConvertor, QuestionFilter>,
            IQuestionListService
    {
        private readonly IBankOfQuestionRepository _bankOfQuestionRepository;

        public QuestionListService(
            IBankOfQuestionRepository bankOfQuestionRepository,
            IQuestionRepository repository,
            IQuestionListConvertor convertor
        )
            : base(repository, convertor)
        {
            _bankOfQuestionRepository = bankOfQuestionRepository;
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _bankOfQuestionRepository.GetOrganizationId(objectId);
        }

        protected override Expression<Func<QuestionDbo, bool>> PrepareSqlFilter(QuestionFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(QuestionDbo), "question");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterTranslation<QuestionTranslationDbo>(
                filter.Question,
                culture,
                parameter,
                expression,
                nameof(QuestionTranslationDbo.Question),
                nameof(QuestionTranslationDbo.Culture),
                nameof(QuestionDbo.TestQuestionTranslation)
            );
            expression = FilterGuid(filter.AnswerModeId, parameter, expression, nameof(QuestionDbo.AnswerModeId));
            expression = FilterGuid(filter.QuestionModeId, parameter, expression, nameof(QuestionDbo.QuestionModeId));
            return Expression.Lambda<Func<QuestionDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<QuestionDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            if (columnName == QuestionSort.Question.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(QuestionDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(QuestionDbo.TestQuestionTranslation));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(QuestionTranslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(QuestionTranslationDbo.Question));
                Expression<Func<QuestionDbo, object>> lambda = Expression.Lambda<Func<QuestionDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<QuestionDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            else if (columnName == QuestionSort.AnswerMode.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(QuestionDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(QuestionDbo.AnswerMode));
                MemberExpression nameProperty = Expression.Property(property, nameof(AnswerModeDbo.Name));
                Expression<Func<QuestionDbo, object>> lambda = Expression.Lambda<Func<QuestionDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<QuestionDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            else if (columnName == QuestionSort.QuestionMode.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(QuestionDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(QuestionDbo.QuestionMode));
                MemberExpression nameProperty = Expression.Property(property, nameof(QuestionModeDbo.Name));
                Expression<Func<QuestionDbo, object>> lambda = Expression.Lambda<Func<QuestionDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<QuestionDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
