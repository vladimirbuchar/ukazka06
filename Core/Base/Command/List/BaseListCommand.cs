using Core.Base.Convertor;
using Core.Base.Dto;
using Core.Base.Filter;
using Core.Base.Paging;
using Core.Base.Repository;
using Core.Base.Sort;
using Core.DataTypes;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Core.Base.Command.List
{
    public abstract class BaseListCommand<TModel, TRepository, TObjectList, TConvertor, TFilter>(TRepository repository, TConvertor convertor) : IBaseListCommand<TModel, TObjectList, TFilter>
        where TObjectList : ListDto
        where TModel : TableModel
        where TFilter : RequestFilter
        where TRepository : IBaseRepository<TModel>
        where TConvertor : IBaseListConvertor<TModel, TObjectList>
    {
        protected readonly TRepository _repository = repository;
        protected readonly TConvertor _convertor = convertor;

        public virtual async Task<ResultTable<TObjectList>> Execute(
            Expression<Func<TModel, bool>> predicate = null,
            bool deleted = false,
            List<string> culture = null,
            TFilter filter = null,
            string sortColumn = "",
            SortDirection sortDirection = SortDirection.Ascending,
            BasePaging paging = null
        )
        {
            paging ??= new BasePaging();
            List<TModel> entities = await _repository.GetEntities(
                deleted,
                predicate,
                PrepareSqlFilter(filter, culture.First()),
                PrepareSort(sortColumn, culture.First(), sortDirection),
                paging
            );
            List<TObjectList> data = await _convertor.ConvertToWebModel(entities, culture);
            int count = await _repository.GetTotalCount(deleted, predicate, PrepareSqlFilter(filter, culture.First()));
            ResultTable<TObjectList> result = new() { Data = data, TotalCount = count };
            return result;
        }

        public async Task<ResultTable<TObjectList>> Execute(List<string> culture = null, TFilter filter = null)
        {
            return await Execute(null, false, culture, filter);
        }

        public virtual async Task<ResultTable<TObjectList>> Execute(bool deleted = false, List<string> culture = null)
        {
            return await Execute(null, deleted, culture);
        }

        public virtual async Task<ResultTable<TObjectList>> Execute()
        {
            return await Execute(null, false, null);
        }

        protected virtual Expression<Func<TModel, bool>> PrepareSqlFilter(TFilter filter, string culture)
        {
            return null;
        }

        protected virtual List<BaseSort<TModel>> PrepareSort(string columnName, string culture, SortDirection sortDirection = SortDirection.Ascending)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                ParameterExpression parameter = Expression.Parameter(typeof(TModel), "x");
                MemberExpression property = Expression.Property(parameter, columnName);
                Expression<Func<TModel, object>> lambda = Expression.Lambda<Func<TModel, object>>(
                    Expression.Convert(property, typeof(object)),
                    parameter
                );
                return [new BaseSort<TModel>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return null;
        }

        protected Expression FilterDate(
            DateTime? dateTimeFrom,
            DateTime? dateTimeTo,
            ParameterExpression parameter,
            Expression expression,
            params string[] columnNames
        )
        {
            if (columnNames == null || columnNames.Length == 0)
            {
                throw new ArgumentException("At least one column name must be specified.", nameof(columnNames));
            }

            Expression combinedExpression = null;

            foreach (string columnName in columnNames)
            {
                // Create the property access expression
                MemberExpression property = Expression.Property(parameter, columnName);

                // Ensure property is of type DateTime? or DateTime
                if (property.Type != typeof(DateTime?) && property.Type != typeof(DateTime))
                {
                    throw new ArgumentException($"The property '{columnName}' is not of type DateTime or DateTime?.", nameof(columnNames));
                }

                // Handle nullable DateTime by accessing the Value property and checking HasValue
                MemberExpression hasValue = Expression.Property(property, "HasValue");
                MemberExpression value = Expression.Property(property, "Value");

                Expression dateRangeExpression = null;

                // Create the 'from' date comparison expression if dateTimeFrom is not null
                if (dateTimeFrom.HasValue)
                {
                    ConstantExpression fromDate = Expression.Constant(dateTimeFrom.Value, typeof(DateTime));
                    BinaryExpression fromComparison = Expression.GreaterThanOrEqual(value, fromDate);
                    dateRangeExpression = fromComparison;
                }

                // Create the 'to' date comparison expression if dateTimeTo is not null
                if (dateTimeTo.HasValue)
                {
                    ConstantExpression toDate = Expression.Constant(dateTimeTo.Value, typeof(DateTime));
                    BinaryExpression toComparison = Expression.LessThanOrEqual(value, toDate);
                    dateRangeExpression =
                        dateRangeExpression == null ? toComparison : (Expression)Expression.AndAlso(dateRangeExpression, toComparison);
                }

                if (dateRangeExpression != null)
                {
                    // Only apply the date range if the property has a value
                    BinaryExpression condition = Expression.AndAlso(hasValue, dateRangeExpression);

                    // Combine with the existing expression
                    combinedExpression = combinedExpression == null ? condition : (Expression)Expression.AndAlso(combinedExpression, condition);
                }
            }

            // Combine the new date range expressions with the existing expression
            return expression == null ? combinedExpression : Expression.AndAlso(expression, combinedExpression);
        }

        protected Expression FilterGuid(List<Guid> guids, ParameterExpression parameter, Expression expression, params string[] columnName)
        {
            if (guids != null && guids.Count > 0)
            {
                MemberExpression property = null;
                if (columnName.Length == 1)
                {
                    property = Expression.Property(parameter, columnName[0]);
                }
                if (columnName.Length == 2)
                {
                    property = Expression.Property(parameter, columnName[0]);
                    property = Expression.Property(property, columnName[1]);
                }
                System.Reflection.MethodInfo containsMethod = typeof(List<Guid>).GetMethod("Contains", [typeof(Guid)]);

                Expression containsExpression;
                if (IsNullableProperty(property))
                {
                    // Handle nullable Guid property
                    MemberExpression valueProperty = Expression.Property(property, "Value");
                    MemberExpression hasValueProperty = Expression.Property(property, "HasValue");
                    containsExpression = Expression.Call(Expression.Constant(guids), containsMethod, valueProperty);
                    BinaryExpression condition = Expression.AndAlso(hasValueProperty, containsExpression);
                    expression = Expression.AndAlso(expression, condition);
                }
                else
                {
                    // Handle non-nullable Guid property
                    containsExpression = Expression.Call(Expression.Constant(guids), containsMethod, property);
                    expression = Expression.AndAlso(expression, containsExpression);
                }
            }
            return expression;
        }

        protected Expression FilterIntRange(int? minValue, int? maxValue, ParameterExpression parameter, Expression expression, string columnName)
        {
            if (minValue.HasValue)
            {
                expression = Expression.AndAlso(
                    expression,
                    Expression.GreaterThanOrEqual(Expression.Property(parameter, columnName), Expression.Constant(minValue.Value))
                );
            }

            if (maxValue.HasValue)
            {
                expression = Expression.AndAlso(
                    expression,
                    Expression.LessThanOrEqual(Expression.Property(parameter, columnName), Expression.Constant(maxValue.Value))
                );
            }

            return expression;
        }

        protected Expression FilterDouble(double? value, ParameterExpression parameter, Expression expression, string columnName)
        {
            if (value.HasValue)
            {
                // Get the property type
                Type propertyType = parameter.Type.GetProperty(columnName).PropertyType;

                // If the property is an int, convert it to double before comparison
                Expression left = Expression.Property(parameter, columnName);
                if (propertyType == typeof(int))
                {
                    left = Expression.Convert(left, typeof(double));
                }

                // Create the comparison expression
                expression = Expression.AndAlso(expression, Expression.Equal(left, Expression.Constant(value.Value)));
            }
            return expression;
        }

        protected Expression FilterInt(int? value, ParameterExpression parameter, Expression expression, string columnName)
        {
            if (value.HasValue)
            {
                expression = Expression.AndAlso(
                    expression,
                    Expression.Equal(Expression.Property(parameter, columnName), Expression.Constant(value.Value))
                );
            }
            return expression;
        }

        protected Expression FilterTranslation<T>(
            string translationName,
            string culture,
            ParameterExpression parameter,
            Expression expression,
            string columnName,
            string cultureColumn,
            string translationsName
        )
            where T : TranslationTableModel
        {
            if (!string.IsNullOrEmpty(translationName) && !string.IsNullOrEmpty(culture))
            {
                MemberExpression translationsProperty = Expression.Property(parameter, translationsName);
                ParameterExpression translationParameter = Expression.Parameter(typeof(T), "translation");

                Expression nameContainsExpression = null;
                Expression cultureEqualsExpression = null;

                if (!string.IsNullOrEmpty(translationName))
                {
                    MemberExpression nameProperty = Expression.Property(translationParameter, columnName);
                    ConstantExpression nameConstant = Expression.Constant(translationName);
                    System.Reflection.MethodInfo containsMethod = typeof(string).GetMethod("Contains", [typeof(string)]);
                    nameContainsExpression = Expression.Call(nameProperty, containsMethod, nameConstant);
                }

                if (!string.IsNullOrEmpty(culture))
                {
                    MemberExpression cultureProperty = Expression.Property(translationParameter, cultureColumn);
                    MemberExpression systemIdentificatorProperty = Expression.Property(cultureProperty, "SystemIdentificator");
                    ConstantExpression cultureConstant = Expression.Constant(culture);
                    cultureEqualsExpression = Expression.Equal(systemIdentificatorProperty, cultureConstant);
                }

                Expression combinedExpression = null;
                if (nameContainsExpression != null && cultureEqualsExpression != null)
                {
                    combinedExpression = Expression.AndAlso(nameContainsExpression, cultureEqualsExpression);
                }
                else if (nameContainsExpression != null)
                {
                    combinedExpression = nameContainsExpression;
                }
                else if (cultureEqualsExpression != null)
                {
                    combinedExpression = cultureEqualsExpression;
                }

                System.Reflection.MethodInfo anyMethod = typeof(Enumerable)
                    .GetMethods()
                    .First(m => m.Name == "Any" && m.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T));
                MethodCallExpression anyExpression = Expression.Call(
                    anyMethod,
                    translationsProperty,
                    Expression.Lambda<Func<T, bool>>(combinedExpression, translationParameter)
                );
                expression = Expression.AndAlso(expression, anyExpression);
            }
            return expression;
        }

        protected Expression FilterString(List<string> strings, ParameterExpression parameter, Expression expression, params string[] columnName)
        {
            if (strings != null && strings.Count > 0)
            {
                if (columnName.Length == 1)
                {
                    MemberExpression property = Expression.Property(parameter, columnName[0]);
                    System.Reflection.MethodInfo containsMethod = typeof(List<string>).GetMethod("Contains", [typeof(string)]);
                    Expression containsExpression = Expression.Call(Expression.Constant(strings), containsMethod, property);
                    expression = Expression.AndAlso(expression, containsExpression);
                }
                else if (columnName.Length == 2)
                {
                    MemberExpression property = Expression.Property(parameter, columnName[0]);
                    System.Reflection.MethodInfo containsMethod = typeof(List<string>).GetMethod("Contains", [typeof(string)]);
                    MemberExpression property1 = Expression.Property(property, columnName[1]);
                    Expression containsExpression = Expression.Call(Expression.Constant(strings), containsMethod, property1);
                    expression = Expression.AndAlso(expression, containsExpression);
                }
            }
            return expression;
        }

        protected Expression FilterString(string value, ParameterExpression parameter, Expression expression, params string[] columnName)
        {
            if (!string.IsNullOrEmpty(value) && columnName.Length > 0)
            {
                MemberExpression property = Expression.Property(parameter, columnName[0]);
                for (int i = 1; i < columnName.Length; i++)
                {
                    property = Expression.Property(property, columnName[i]);
                }

                System.Reflection.MethodInfo containsMethod = typeof(string).GetMethod("Contains", [typeof(string)]);
                MethodCallExpression containsExpression = Expression.Call(property, containsMethod, Expression.Constant(value));

                expression = Expression.AndAlso(expression, containsExpression);
            }
            return expression;
        }

        protected Expression FilterBool(bool? value, ParameterExpression parameter, Expression expression, string columnName)
        {
            if (value.HasValue)
            {
                expression = Expression.AndAlso(
                    expression,
                    Expression.Equal(Expression.Property(parameter, columnName), Expression.Constant(value.Value))
                );
            }
            return expression;
        }

        private static bool IsNullableProperty(MemberExpression memberExpression)
        {
            // Get the type of the property
            Type propertyType = memberExpression.Type;

            // Check if the type is a nullable type
            if (Nullable.GetUnderlyingType(propertyType) != null)
            {
                return true;
            }

            // Additionally, check if the property type is a reference type (which is nullable)
            return !propertyType.IsValueType;
        }

        public virtual async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await Task.FromResult(Guid.Empty);
        }

        public virtual async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await _repository.GetOrganizationId(objectId);
        }
    }
}
