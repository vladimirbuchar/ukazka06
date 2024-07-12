using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using Model.CodeBook;
using Model.Edu.Question;
using Repository.BankOfQuestionRepository;
using Repository.QuestionRepository;
using Services.Question.Convertor;
using Services.Question.Dto;
using Services.Question.Filter;
using Services.Question.Sort;
using Services.Question.Validator;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Question.Service
{
    public class QuestionService(
        IQuestionRepository questionRepository,
        IQuestionConvertor questionConvertor,
        IQuestionValidator validator,
        IFileUploadRepository<QuestionFileRepositoryDbo> fileRepository,
        ICodeBookRepository<CultureDbo> codeBookRepository,
        IBankOfQuestionRepository bankOfQuestionRepository
    )
        : BaseService<
            IQuestionRepository,
            QuestionDbo,
            IQuestionConvertor,
            IQuestionValidator,
            QuestionCreateDto,
            QuestionListDto,
            QuestionDetailDto,
            QuestionUpdateDto,
            QuestionFileRepositoryDbo,
            QuestionFilter
        >(questionRepository, questionConvertor, validator, fileRepository, codeBookRepository),
            IQuestionService
    {
        private readonly IBankOfQuestionRepository _bankOfQuestionRepository = bankOfQuestionRepository;

        public override Guid GetOrganizationIdByParentId(Guid objectId)
        {
            return _bankOfQuestionRepository.GetOrganizationId(objectId);
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

        protected override Expression<Func<QuestionDbo, object>> PrepareSort(string columnName, string culture)
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
                return lambda;
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
                return lambda;
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
                return lambda;
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
