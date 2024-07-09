using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Base.Convertor;
using Core.Base.Dto;
using Core.Base.Repository;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Request;
using Core.Base.Validator;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Model;
using Model.CodeBook;

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
        private List<CultureDbo> Culture { get; set; } = codeBookRepository.GetEntities(false).Result;

        /// <summary>
        /// file upload
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="culture"></param>
        /// <param name="userId"></param>
        /// <param name="files"></param>
        /// <param name="model"></param>
        /// <param name="deleteFiles"></param>
        public virtual Result FileUpload(
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
                List<FileModel> fileDelete = _fileRepository.GetEntities(false, deleteFiles).Result;
                foreach (FileModel item in fileDelete)
                {
                    _fileRepository.DeleteEntity(item, userId);
                }
            }
            Guid cultureId = Culture.FirstOrDefault(x => x.SystemIdentificator == culture).Id;
            model.CultureId = cultureId;
            foreach (IFormFile file in files)
            {
                _ = _fileRepository.FileUpload(model, parentId, file, userId);
            }
            return new Result();
        }

        /// <summary>
        /// file delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public virtual Result FileDelete(Guid id, Guid userId)
        {
            _fileRepository.DeleteEntity(id, userId);
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
        public virtual Result<Detail> UpdateObject(Update update, Guid userId, string culture, Result<Detail> result = null)
        {
            Model oldEntity = _repository.GetEntity(update.Id) ?? throw new KeyNotFoundException(update.Id.ToString());
            result ??= _validator.IsValid(update);
            if (result.IsOk)
            {
                Model entity = _convertor.ConvertToBussinessEntity(update, oldEntity, culture);
                if (IsChanged(_repository.GetEntity(update.Id), update, culture))
                {
                    entity = _repository.UpdateEntity(entity, userId);
                    result.DataChanged = true;
                }
                result.Data = _convertor.ConvertToWebModel(entity, culture);
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
        where Validator : IBaseValidator<Model, Repository, Create, Detail>
        where Filter : FilterRequest
    {
        /// <summary>
        /// add object
        /// </summary>
        /// <param name="addObject"></param>
        /// <param name="userId"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public virtual Result<Detail> AddObject(Create addObject, Guid userId, string culture)
        {
            Result<Detail> result = _validator.IsValid(addObject);
            if (result.IsOk)
            {
                Model entity = _convertor.ConvertToBussinessEntity(addObject, culture);
                entity = _repository.CreateEntity(entity, userId);
                result.Data = _convertor.ConvertToWebModel(entity, culture);
            }
            return result;
        }

        /// <summary>
        /// delete object
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="userId"></param>
        public virtual Result DeleteObject(Guid objectId, Guid userId)
        {
            _repository.DeleteEntity(objectId, userId);
            return new Result();
        }

        /// <summary>
        /// restore object
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="userId"></param>
        public virtual Result RestoreObject(Guid objectId, Guid userId)
        {
            _repository.RestoreEntity(objectId, userId);
            return new Result();
        }

        /// <summary>
        /// delete objects by condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="userId"></param>
        public virtual Result MultipleDelete(Expression<Func<Model, bool>> predicate, Guid userId)
        {
            List<Guid> ids = _repository.GetEntities(false, predicate).Result.Select(x => x.Id).ToList();
            foreach (Guid id in ids)
            {
                _repository.DeleteEntity(id, userId);
            }
            return new Result();
        }

        /// <summary>
        /// get object list
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="deleted"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public virtual List<ObjectList> GetList(
            Expression<Func<Model, bool>> predicate = null,
            bool deleted = false,
            string culture = "",
            Filter filter = null
        )
        {
            List<Model> entities = _repository.GetEntities(deleted, predicate, PrepareSqlFilter(filter, culture)).Result;
            entities = PrepareMemoryFilter(entities, filter, culture);
            return _convertor.ConvertToWebModel(entities, culture);
        }

        public virtual List<ObjectList> GetList(bool deleted = false, string culture = "")
        {
            return GetList(null, deleted, culture);
        }

        public virtual List<ObjectList> GetList()
        {
            return GetList(null, false, string.Empty);
        }

        protected virtual Expression<Func<Model, bool>> PrepareSqlFilter(Filter filter, string culture)
        {
            return null;
        }

        protected virtual List<Model> PrepareMemoryFilter(List<Model> entities, Filter filter, string culture)
        {
            return entities;
        }

        /// <summary>
        /// get object detail
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public virtual Detail GetDetail(Guid objectId, string culture)
        {
            return _convertor.ConvertToWebModel(_repository.GetEntity(objectId), culture);
        }

        /// <summary>
        /// get object detail by condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public virtual Detail GetDetail(Expression<Func<Model, bool>> predicate, string culture)
        {
            return _convertor.ConvertToWebModel(_repository.GetEntity(false, predicate), culture);
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

        public Expression<Func<Guid, bool>> FilterGuid(Guid? value, ParameterExpression parameter, Expression expression, string columnName)
        {
            if (value.HasValue)
            {
                MemberExpression property = Expression.Property(parameter, columnName);
                ConstantExpression constant = Expression.Constant(value.Value);
                BinaryExpression equality = Expression.Equal(property, constant);
                expression = Expression.AndAlso(expression, equality);
            }
            return Expression.Lambda<Func<Guid, bool>>(expression, parameter);
        }

        protected Expression FilterString(string value, ParameterExpression parameter, Expression expression, string columnName)
        {
            if (!string.IsNullOrEmpty(value))
            {
                MemberExpression property = Expression.Property(parameter, columnName);
                System.Reflection.MethodInfo containsMethod = typeof(string).GetMethod("Contains", [typeof(string)]);
                MethodCallExpression containsExpression = Expression.Call(property, containsMethod, Expression.Constant(value));
                expression = Expression.AndAlso(expression, containsExpression);
            }
            return expression;
        }

        public List<ObjectList> GetList(string culture = "", Filter filter = null)
        {
            return GetList(null, false, culture, filter);
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

        public override Guid GetOrganizationIdByObjectId(Guid objectId)
        {
            return _repository.GetOrganizationId(objectId);
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

        public virtual Guid GetOrganizationIdByObjectId(Guid objectId)
        {
            return Guid.Empty;
        }

        public virtual Guid GetOrganizationIdByParentId(Guid objectId)
        {
            return Guid.Empty;
        }
    }
}
