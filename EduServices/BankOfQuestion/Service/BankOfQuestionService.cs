using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.BankOfQuestions;
using Model.Edu.Question;
using Repository.BankOfQuestionRepository;
using Repository.QuestionRepository;
using Services.BankOfQuestion.Convertor;
using Services.BankOfQuestion.Dto;
using Services.BankOfQuestion.Filter;
using Services.BankOfQuestion.Sort;
using Services.BankOfQuestion.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.BankOfQuestion.Service
{
    public class BankOfQuestionService(
        IBankOfQuestionRepository bankOfQuestionRepository,
        IQuestionRepository questionRepository,
        IBankOfQuestionConvertor bankOfQuestionConvertor,
        IBankOfQuestionValidator validator
    )
        : BaseService<
            IBankOfQuestionRepository,
            BankOfQuestionDbo,
            IBankOfQuestionConvertor,
            IBankOfQuestionValidator,
            BankOfQuestionCreateDto,
            BankOfQuestionListDto,
            BankOfQuestionDetailDto,
            BankOfQuestionUpdateDto,
            BankOfQuestionFilter
        >(bankOfQuestionRepository, bankOfQuestionConvertor, validator),
            IBankOfQuestionService
    {
        private readonly IQuestionRepository _questionRepository = questionRepository;

        public override Result DeleteObject(Guid objectId, Guid userId)
        {
            List<QuestionDbo> getQuestionsInBanks = _questionRepository.GetEntities(false, x => x.BankOfQuestionId == objectId).Result;
            Guid organizationId = _repository.GetEntity(objectId).OrganizationId;
            Guid defaultBankOfQuestion = _repository.GetEntity(false, x => x.OrganizationId == organizationId && x.IsDefault).Id;
            foreach (QuestionDbo item in getQuestionsInBanks)
            {
                item.BankOfQuestionId = defaultBankOfQuestion;
                _ = _questionRepository.UpdateEntity(item, userId);
            }
            _repository.DeleteEntity(objectId, userId);
            return new Result();
        }

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

        protected override Expression<Func<BankOfQuestionDbo, object>> PrepareSort(string columnName, string culture)
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
                return lambda;
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
