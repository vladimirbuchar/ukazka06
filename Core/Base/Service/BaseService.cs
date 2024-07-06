using Core.Base.Convertor;
using Core.Base.Dto;
using Core.Base.Repository;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Validator;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Model;
using Model.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Base.Service
{
    public class BaseService<Repository, Model, Convertor, Validator, Create, ObjectĹist, Detail, Update, FileModel>(
        Repository repository,
        Convertor convertor,
        Validator validator,
        IFileUploadRepository<FileModel> fileRepository,
        ICodeBookRepository<CultureDbo> codeBookRepository
    ) : BaseService<Repository, Model, Convertor, Validator, Create, ObjectĹist, Detail, Update>(repository, convertor, validator), IBaseService<Model, Create, ObjectĹist, Detail, Update>
        where Repository : IBaseRepository<Model>
        where Model : TableModel
        where Create : CreateDto
        where Update : UpdateDto
        where ObjectĹist : ListDto
        where Detail : DetailDto
        where Convertor : IBaseConvertor<Model, Create, ObjectĹist, Detail, Update>
        where Validator : IBaseValidator<Model, Repository, Create, Detail, Update>
        where FileModel : FileRepositoryModel
    {
        protected readonly IFileUploadRepository<FileModel> _fileRepository = fileRepository;
        private HashSet<CultureDbo> Culture { get; set; } = codeBookRepository.GetEntities(false);

        /// <summary>
        /// file upload 
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="culture"></param>
        /// <param name="userId"></param>
        /// <param name="files"></param>
        /// <param name="model"></param>
        /// <param name="deleteFiles"></param>
        public virtual Result FileUpload(Guid parentId, string culture, Guid userId, List<IFormFile> files, FileModel model, Expression<Func<FileModel, bool>> deleteFiles = null)
        {
            _fileRepository.CreateFileRepository(parentId);
            if (deleteFiles != null)
            {
                HashSet<FileModel> fileDelete = _fileRepository.GetEntities(false, deleteFiles);
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

    public class BaseService<Repository, Model, Convertor, Validator, Create, ObjectĹist, Detail, Update>(Repository repository, Convertor convertor, Validator validator)
        : BaseService<Repository, Model, Convertor, Validator, Create, ObjectĹist, Detail>(repository, convertor, validator),
            IBaseService<Model, Create, ObjectĹist, Detail>
        where Repository : IBaseRepository<Model>
        where Model : TableModel
        where Create : CreateDto
        where Update : UpdateDto
        where ObjectĹist : ListDto
        where Detail : DetailDto
        where Convertor : IBaseConvertor<Model, Create, ObjectĹist, Detail, Update>
        where Validator : IBaseValidator<Model, Repository, Create, Detail, Update>
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

    public class BaseService<Repository, Model, Convertor, Validator, Create, ObjectĹist, Detail>(Repository repository, Convertor convertor, Validator validator)
        : BaseService<Repository, Model, Convertor, Validator>(repository, convertor, validator),
            IBaseService<Model, Create, ObjectĹist, Detail>
        where Repository : IBaseRepository<Model>
        where Model : TableModel
        where Create : CreateDto
        where ObjectĹist : ListDto
        where Detail : DetailDto
        where Convertor : IBaseConvertor<Model, Create, ObjectĹist, Detail>
        where Validator : IBaseValidator<Model, Repository, Create, Detail>
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
            HashSet<Guid> ids = _repository.GetEntities(false, predicate).Select(x => x.Id).ToHashSet();
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
        public virtual HashSet<ObjectĹist> GetList(Expression<Func<Model, bool>> predicate = null, bool deleted = false, string culture = "")
        {
            return _convertor.ConvertToWebModel(_repository.GetEntities(deleted, predicate), culture);
        }

        public virtual HashSet<ObjectĹist> GetList(bool deleted = false, string culture = "")
        {
            return GetList(null, deleted, culture);
        }
        public virtual HashSet<ObjectĹist> GetList()
        {
            return GetList(null, false, string.Empty);
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
    }

    public abstract class BaseService<Repository, Model, Convertor, Validator>(Repository repository, Convertor convertor, Validator validator)
        : BaseService<Repository, Model, Convertor>(repository, convertor)
        where Repository : IBaseRepository<Model>
        where Convertor : IBaseConvertor
        where Model : TableModel
    {
        protected Validator _validator = validator;
    }

    public abstract class BaseService<Repository, Model, Convertor>(Repository repository, Convertor convertor) : BaseService<Repository, Model>(repository)
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
    }
}
