using Core.Base.Convertor;
using Core.Base.Dto;
using Core.Base.Filter;
using Core.Base.Paging;
using Core.Base.Repository;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Sort;
using Core.Base.Validator;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Model;
using Model.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Core.Base.Service
{

    public class BaseService<Repository, Model, Convertor, Validator, Create, ObjectList, Detail, Update, FileModel, Filter>(
        Repository repository,
        Convertor convertor,
        Validator validator,
        IFileUploadRepository<FileModel> fileRepository,
        ICodeBookRepository<CultureDbo> codeBookRepository
    )
        : BaseService<Repository, Model, Convertor, Validator, Create, ObjectList, Detail, Update, Filter>(repository, convertor, validator),
            IBaseService<Model, Create, ObjectList, Detail, Update, Filter>
        where Repository : IBaseRepository<Model>
        where Model : TableModel
        where Create : CreateDto
        where Update : UpdateDto
        where ObjectList : ListDto
        where Detail : DetailDto
        where Convertor : IBaseConvertor<Model, Create, ObjectList, Detail, Update>
        where Validator : IBaseValidator<Model, Repository, Create, Detail, Update>
        where FileModel : FileRepositoryModel
        where Filter : FilterRequest
    {
        protected readonly IFileUploadRepository<FileModel> _fileRepository = fileRepository;
        private ICodeBookRepository<CultureDbo> Culture { get; set; } = codeBookRepository;

        /// <summary>
        /// file upload
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="culture"></param>
        /// <param name="userId"></param>
        /// <param name="files"></param>
        /// <param name="model"></param>
        /// <param name="deleteFiles"></param>
        public virtual async Task<Result> FileUpload(
            Guid parentId,
            string culture,
            Guid userId,
            List<IFormFile> files,
            FileModel model,
            Expression<Func<FileModel, bool>> deleteFiles = null
        )
        {
            _fileRepository.CreateFileRepository(parentId);
            if (deleteFiles != null)
            {
                List<FileModel> fileDelete = await _fileRepository.GetEntities(false, deleteFiles);
                foreach (FileModel item in fileDelete)
                {
                    await _fileRepository.DeleteEntity(item, userId);
                }
            }
            Guid cultureId = (await Culture.GetEntity(false, x => x.SystemIdentificator == culture)).Id;
            model.CultureId = cultureId;
            foreach (IFormFile file in files)
            {
                _ = await _fileRepository.FileUpload(model, parentId, file, userId);
            }
            return new Result();
        }

        /// <summary>
        /// file delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public virtual async Task<Result> FileDelete(Guid id, Guid userId)
        {
            await _fileRepository.DeleteEntity(id, userId);
            return new Result();
        }

    }

    public class BaseService<Repository, Model, Convertor, Validator, Create, ObjectList, Detail, Update, Filter>(
        Repository repository,
        Convertor convertor,
        Validator validator
    )
        : BaseService<Repository, Model, Convertor, Validator, Create, ObjectList, Detail, Filter>(repository, convertor, validator),
            IBaseService<Model, Create, ObjectList, Detail, Filter>
        where Repository : IBaseRepository<Model>
        where Model : TableModel
        where Create : CreateDto
        where Update : UpdateDto
        where ObjectList : ListDto
        where Detail : DetailDto
        where Convertor : IBaseConvertor<Model, Create, ObjectList, Detail, Update>
        where Validator : IBaseValidator<Model, Repository, Create, Detail, Update>
        where Filter : FilterRequest
    {
        /// <summary>
        /// update object
        /// </summary>
        /// <param name="update"></param>
        /// <param name="userId"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public virtual async Task<Result<Detail>> UpdateObject(Update update, Guid userId, string culture, Result<Detail> result = null)
        {
            Model oldEntity = await _repository.GetEntity(update.Id) ?? throw new KeyNotFoundException(update.Id.ToString());
            result ??= await _validator.IsValid(update);
            if (result.IsOk)
            {
                Model entity = await _convertor.ConvertToBussinessEntity(update, oldEntity, culture);
                if (IsChanged(await _repository.GetEntity(update.Id), update, culture))
                {
                    entity = await _repository.UpdateEntity(entity, userId);
                    result.DataChanged = true;
                }
                result.Data = await _convertor.ConvertToWebModel(entity, culture);
            }
            return result;
        }

        /// <summary>
        /// test that is object change
        /// </summary>
        /// <param name="oldVersion"></param>
        /// <param name="newVersion"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected virtual bool IsChanged(Model oldVersion, Update newVersion, string culture)
        {
            return true;
        }
    }

    public class BaseService<Repository, Model, Convertor, Validator, Create, ObjectList, Detail, Filter>(
        Repository repository,
        Convertor convertor,
        Validator validator
    )
        : BaseService<Repository, Model, Convertor, Validator>(repository, convertor, validator),
            IBaseService<Model, Create, ObjectList, Detail, Filter>
        where Repository : IBaseRepository<Model>
        where Model : TableModel
        where Create : CreateDto
        where ObjectList : ListDto
        where Detail : DetailDto
        where Convertor : IBaseConvertor<Model, Create, ObjectList, Detail>
        where Validator : IBaseValidatorCreate<Model, Repository, Create>
        where Filter : FilterRequest
    {
        /// <summary>
        /// add object
        /// </summary>
        /// <param name="addObject"></param>
        /// <param name="userId"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public virtual async Task<Result> AddObject(Create addObject, Guid userId, string culture)
        {
            Result result = await _validator.IsValid(addObject);
            if (result.IsOk)
            {
                Model entity = await _convertor.ConvertToBussinessEntity(addObject, culture);
                _ = await _repository.CreateEntity(entity, userId);
                //result.Data = await _convertor.ConvertToWebModel(entity, culture);
            }
            return result;
        }

        /// <summary>
        /// delete object
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="userId"></param>
        public virtual async Task<Result> DeleteObject(Guid objectId, Guid userId)
        {
            await _repository.DeleteEntity(objectId, userId);
            return new Result();
        }

        /// <summary>
        /// restore object
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="userId"></param>
        public virtual async Task<Result> RestoreObject(Guid objectId, Guid userId)
        {
            await _repository.RestoreEntity(objectId, userId);
            return new Result();
        }

        /// <summary>
        /// get object list
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="deleted"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public virtual async Task<ResultTable<ObjectList>> GetList(
            Expression<Func<Model, bool>> predicate = null,
            bool deleted = false,
            string culture = "",
            Filter filter = null,
            string sortColumn = "",
            SortDirection sortDirection = SortDirection.Ascending,
            BasePaging paging = null
        )
        {
            paging ??= new BasePaging();
            List<Model> entities = await _repository
                .GetEntities(
                    deleted,
                    predicate,
                    PrepareSqlFilter(filter, culture),
                    PrepareSort(sortColumn, culture, sortDirection),
                    paging
                );
            List<ObjectList> data = await _convertor.ConvertToWebModel(entities, culture);
            int count = await _repository.GetTotalCount(deleted, predicate, PrepareSqlFilter(filter, culture));
            ResultTable<ObjectList> result = new()
            {
                Data = data,
                TotalCount = count
            };
            return result;
        }

        public virtual async Task<ResultTable<ObjectList>> GetList(bool deleted = false, string culture = "")
        {
            return await GetList(null, deleted, culture);
        }

        public virtual async Task<ResultTable<ObjectList>> GetList()
        {
            return await GetList(null, false, string.Empty);
        }

        protected virtual Expression<Func<Model, bool>> PrepareSqlFilter(Filter filter, string culture)
        {
            return null;
        }

        protected virtual List<BaseSort<Model>> PrepareSort(string columnName, string culture, SortDirection sortDirection = SortDirection.Ascending)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                ParameterExpression parameter = Expression.Parameter(typeof(Model), "x");
                MemberExpression property = Expression.Property(parameter, columnName);
                Expression<Func<Model, object>> lambda = Expression.Lambda<Func<Model, object>>(
                    Expression.Convert(property, typeof(object)),
                    parameter
                );
                return
                [
                    new BaseSort<Model>()
                    {
                        Sort = lambda,
                        SortDirection = sortDirection
                    }
                ];
            }
            return null;
        }

        /// <summary>
        /// get object detail
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public virtual async Task<Detail> GetDetail(Guid objectId, string culture)
        {
            Model model = await _repository.GetEntity(objectId);
            Detail detail = await _convertor.ConvertToWebModel(model, culture);
            return detail;
        }

        /// <summary>
        /// get object detail by condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public virtual async Task<Detail> GetDetail(Expression<Func<Model, bool>> predicate, string culture)
        {
            Model entity = await _repository.GetEntity(false, predicate);
            Detail detail = await _convertor.ConvertToWebModel(entity, culture);
            return detail;
        }

        public async Task<ResultTable<ObjectList>> GetList(string culture = "", Filter filter = null)
        {
            return await GetList(null, false, culture, filter);
        }

        public async Task<Result> MultipleDelete(Expression<Func<Model, bool>> predicate, Guid userId)
        {
            List<Guid> ids = (await _repository.GetEntities(false, predicate)).Select(x => x.Id).ToList();
            foreach (Guid id in ids)
            {
                await _repository.DeleteEntity(id, userId);
            }
            return new Result();
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
                expression = Expression.AndAlso(
                    expression,
                    Expression.Equal(left, Expression.Constant(value.Value))
                );
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

        protected Expression FilterString(string value, ParameterExpression parameter, Expression expression, params string[] columnName)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (columnName.Length == 1)
                {
                    MemberExpression property = Expression.Property(parameter, columnName[0]);
                    System.Reflection.MethodInfo containsMethod = typeof(string).GetMethod("Contains", [typeof(string)]);
                    MethodCallExpression containsExpression = Expression.Call(property, containsMethod, Expression.Constant(value));
                    expression = Expression.AndAlso(expression, containsExpression);
                }
                else if (columnName.Length == 2)
                {
                    MemberExpression property = Expression.Property(parameter, columnName[0]);
                    System.Reflection.MethodInfo containsMethod = typeof(string).GetMethod("Contains", [typeof(string)]);
                    MemberExpression property1 = Expression.Property(property, columnName[1]);
                    MethodCallExpression containsExpression = Expression.Call(property1, containsMethod, Expression.Constant(value));
                    expression = Expression.AndAlso(expression, containsExpression);
                }
                else if (columnName.Length == 3)
                {
                    MemberExpression property = Expression.Property(parameter, columnName[0]);
                    System.Reflection.MethodInfo containsMethod = typeof(string).GetMethod("Contains", [typeof(string)]);
                    MemberExpression property1 = Expression.Property(property, columnName[1]);
                    MemberExpression property2 = Expression.Property(property1, columnName[2]);
                    MethodCallExpression containsExpression = Expression.Call(property2, containsMethod, Expression.Constant(value));
                    expression = Expression.AndAlso(expression, containsExpression);
                }
                else if (columnName.Length == 4)
                {
                    MemberExpression property = Expression.Property(parameter, columnName[0]);
                    System.Reflection.MethodInfo containsMethod = typeof(string).GetMethod("Contains", [typeof(string)]);
                    MemberExpression property1 = Expression.Property(property, columnName[1]);
                    MemberExpression property2 = Expression.Property(property1, columnName[2]);
                    MemberExpression property3 = Expression.Property(property2, columnName[3]);
                    MethodCallExpression containsExpression = Expression.Call(property3, containsMethod, Expression.Constant(value));
                    expression = Expression.AndAlso(expression, containsExpression);
                }
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

        protected Expression FilterDate(DateTime? dateTimeFrom, DateTime? dateTimeTo, ParameterExpression parameter, Expression expression, params string[] columnNames)
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

                // Ensure property is of type DateTime?
                if (property.Type != typeof(DateTime?) && property.Type != typeof(DateTime))
                {
                    throw new ArgumentException($"The property '{columnName}' is not of type DateTime or DateTime?.", nameof(columnNames));
                }

                // Handle nullable DateTime by accessing the Value property and checking HasValue
                MemberExpression hasValue = Expression.Property(property, "HasValue");
                MemberExpression value = Expression.Property(property, "Value");

                // Create the 'from' date comparison expression
                ConstantExpression fromDate = Expression.Constant(dateTimeFrom, typeof(DateTime));
                BinaryExpression fromComparison = Expression.GreaterThanOrEqual(value, fromDate);

                // Create the 'to' date comparison expression
                ConstantExpression toDate = Expression.Constant(dateTimeTo, typeof(DateTime));
                BinaryExpression toComparison = Expression.LessThanOrEqual(value, toDate);

                // Combine the 'from' and 'to' comparisons into one expression
                BinaryExpression dateRangeExpression = Expression.AndAlso(fromComparison, toComparison);

                // Only apply the date range if the property has a value
                BinaryExpression condition = Expression.AndAlso(hasValue, dateRangeExpression);

                // Combine with the existing expression
                combinedExpression = combinedExpression == null ? condition : (Expression)Expression.AndAlso(combinedExpression, condition);
            }

            // Combine the new date range expressions with the existing expression
            return expression == null ? combinedExpression : Expression.AndAlso(expression, combinedExpression);
        }

        protected Expression FilterGuid(List<Guid> guids, ParameterExpression parameter, Expression expression, params string[] columnName)
        {
            if (guids != null && guids.Any())
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
                System.Reflection.MethodInfo containsMethod = typeof(List<Guid>).GetMethod("Contains", new[] { typeof(Guid) });

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

        protected Expression FilterString(List<string> strings, ParameterExpression parameter, Expression expression, params string[] columnName)
        {
            if (strings != null && strings.Any())
            {
                if (columnName.Length == 1)
                {
                    MemberExpression property = Expression.Property(parameter, columnName[0]);
                    System.Reflection.MethodInfo containsMethod = typeof(List<string>).GetMethod("Contains", new[] { typeof(string) });
                    Expression containsExpression = Expression.Call(Expression.Constant(strings), containsMethod, property);
                    expression = Expression.AndAlso(expression, containsExpression);
                }
                else if (columnName.Length == 2)
                {
                    MemberExpression property = Expression.Property(parameter, columnName[0]);
                    System.Reflection.MethodInfo containsMethod = typeof(List<string>).GetMethod("Contains", new[] { typeof(string) });
                    MemberExpression property1 = Expression.Property(property, columnName[1]);
                    Expression containsExpression = Expression.Call(Expression.Constant(strings), containsMethod, property1);
                    expression = Expression.AndAlso(expression, containsExpression);
                }
            }
            return expression;
        }

        protected Expression FilterTranslation<T>(string translationName, string culture, ParameterExpression parameter, Expression expression, string columnName, string cultureColumn, string translationsName)
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
                    System.Reflection.MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
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

                System.Reflection.MethodInfo anyMethod = typeof(Enumerable).GetMethods()
                    .First(m => m.Name == "Any" && m.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T));
                MethodCallExpression anyExpression = Expression.Call(anyMethod, translationsProperty, Expression.Lambda<Func<T, bool>>(combinedExpression, translationParameter));
                expression = Expression.AndAlso(expression, anyExpression);
            }
            return expression;
        }
    }

    public abstract class BaseService<Repository, Model, Convertor, Validator>(Repository repository, Convertor convertor, Validator validator)
        : BaseService<Repository, Model, Convertor>(repository, convertor)
        where Repository : IBaseRepository<Model>
        where Convertor : IBaseConvertor
        where Model : TableModel
    {
        protected Validator _validator = validator;
    }

    public abstract class BaseService<Repository, Model, Convertor>(Repository repository, Convertor convertor)
        : BaseService<Repository, Model>(repository)
        where Repository : IBaseRepository<Model>
        where Convertor : IBaseConvertor
        where Model : TableModel
    {
        protected Convertor _convertor = convertor;
    }


    public abstract class BaseService<Repository, Model>(Repository repository) : BaseService()
        where Repository : IBaseRepository<Model>
        where Model : TableModel
    {
        protected Repository _repository = repository;

        public override async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await _repository.GetOrganizationId(objectId);
        }

        public override async Task<Guid> GetOrganizationIdBFileId(Guid objectId)
        {
            return await _repository.GetOrganizationByFileId(objectId);
        }
    }

    public abstract class BaseService<Convertor>(Convertor convertor) : BaseService()
        where Convertor : IBaseConvertor
    {
        protected Convertor _convertor = convertor;
    }


    public abstract class BaseService : IBaseService
    {
        public BaseService() { }

        public virtual async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await Task.FromResult(Guid.Empty);
        }

        public virtual async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await Task.FromResult(Guid.Empty);
        }
        public virtual async Task<Guid> GetOrganizationIdBFileId(Guid objectId)
        {
            return await Task.FromResult(Guid.Empty);
        }
    }
}
