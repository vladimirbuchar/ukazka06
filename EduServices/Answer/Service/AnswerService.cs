using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using Core.Base.Sort;
using Model.CodeBook;
using Model.Edu.Answer;
using Model.Edu.Branch;
using Repository.AnswerRepository;
using Repository.QuestionRepository;
using Services.Answer.Convertor;
using Services.Answer.Dto;
using Services.Answer.Filter;
using Services.Answer.Sort;
using Services.Answer.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Services.Answer.Service
{
    public class AnswerService(
        IAnswerRepository answerRepository,
        IAnswerConvertor answerConvertor,
        IAnswerValidator answerValidator,
        IFileUploadRepository<AnswerFileRepositoryDbo> fileUploadRepository,
        ICodeBookRepository<CultureDbo> codeBookRepository,
        IQuestionRepository questionRepository
    )
        : BaseService<
            IAnswerRepository,
            AnswerDbo,
            IAnswerConvertor,
            IAnswerValidator,
            AnswerCreateDto,
            AnswerListDto,
            AnswerDetailDto,
            AnswerUpdateDto,
            AnswerFileRepositoryDbo,
            AnswerFilter
        >(answerRepository, answerConvertor, answerValidator, fileUploadRepository, codeBookRepository),
            IAnswerService
    {
        private readonly IQuestionRepository _questionRepository = questionRepository;

        protected override bool IsChanged(AnswerDbo oldVersion, AnswerUpdateDto newVersion, string culture)
        {
            return oldVersion.TestQuestionAnswerTranslations.FindTranslation(culture, true)?.Answer != newVersion.AnswerText
                || newVersion.IsTrueAnswer != oldVersion.IsTrueAnswer;
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

        protected override List<BaseSort<AnswerDbo>> PrepareSort(string columnName, string culture, SortDirection sortDirection = SortDirection.Ascending)
        {
            if (columnName == AnswerSort.Answer.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(AnswerDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(AnswerDbo.TestQuestionAnswerTranslations));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(AnswerTanslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(AnswerTanslationDbo.Answer));
                Expression<Func<AnswerDbo, object>> lambda = Expression.Lambda<Func<AnswerDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return
                [
                    new BaseSort<AnswerDbo>()
                    {
                        Sort = lambda,
                        SortDirection = sortDirection
                    }
                ];
            }

            return base.PrepareSort(columnName, culture);
        }
    }
}
