using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Convertor;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Dto;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Filter;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Sort;
using Core.Base.Command.List;
using Core.Base.Sort;
using Model.Edu.BankOfQuestions;
using Repository.BankOfQuestion;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Command
{
    public class BankOfQuestionListService
        : BaseListCommand<BankOfQuestionDbo, IBankOfQuestionRepository, BankOfQuestionListDto, IBankOfQuestionListConvertor, BankOfQuestionFilter>,
            IBankOfQuestionListService
    {
        public BankOfQuestionListService(IBankOfQuestionRepository repository, IBankOfQuestionListConvertor convertor)
            : base(repository, convertor) { }

        protected override Expression<Func<BankOfQuestionDbo, bool>> PrepareSqlFilter(BankOfQuestionFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(BankOfQuestionDbo), "bankOfQuestion");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterBool(filter.IsDefault, parameter, expression, nameof(BankOfQuestionDbo.IsDefault));
            expression = FilterTranslation<BankOfQuestionsTranslationDbo>(
                filter.Name,
                culture,
                parameter,
                expression,
                nameof(BankOfQuestionsTranslationDbo.Name),
                nameof(BankOfQuestionsTranslationDbo.Culture),
                nameof(BankOfQuestionDbo.BankOfQuestionsTranslations)
            );
            return Expression.Lambda<Func<BankOfQuestionDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<BankOfQuestionDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            if (columnName == BankOfQuestionSort.Name.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(BankOfQuestionDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(BankOfQuestionDbo.BankOfQuestionsTranslations));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(BankOfQuestionsTranslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(BankOfQuestionsTranslationDbo.Name));
                Expression<Func<BankOfQuestionDbo, object>> lambda = Expression.Lambda<Func<BankOfQuestionDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<BankOfQuestionDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
