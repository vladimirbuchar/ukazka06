using Core.Base.Convertor;
using Core.Base.Dto;
using Core.Base.Repository;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.DataTypes;
using Model;
using Model.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Command.Update
{
    public abstract class BaseUpdateCommand<Model, Repository, Update> : BaseCommand<Repository>, IBaseUpdateCommand<Model, Update>
        where Update : UpdateDto
        where Model : TableModel
        where Repository : IBaseRepository<Model>
    {
        protected BaseUpdateCommand(Repository repository)
            : base(repository) { }

        public virtual async Task<Result> Execute(Update update, Guid userId, string culture, Result result = null)
        {
            return await Task.FromResult(new Result());
        }

        public virtual async Task<Result> Execute(
            Update update,
            Guid userId,
            string culture,
            Result result = null,
            Expression<Func<Model, bool>> predicate = null
        )
        {
            return await Task.FromResult(new Result());
        }

        public virtual async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await _repository.GetOrganizationId(objectId);
        }
    }

    public abstract class BaseUpdateCommand<Model, Repository, Update, Validator>
        : BaseUpdateCommand<Model, Repository, Update>,
            IBaseUpdateCommand<Model, Update>
        where Update : UpdateDto
        where Model : TableModel
        where Validator : IBaseUpdateValidator<Model, Update>
        where Repository : IBaseRepository<Model>
    {
        protected BaseUpdateCommand(Repository repository)
            : base(repository) { }

        public override async Task<Result> Execute(Update update, Guid userId, string culture, Result result = null)
        {
            return await Task.FromResult(new Result());
        }

        public override async Task<Result> Execute(
            Update update,
            Guid userId,
            string culture,
            Result result = null,
            Expression<Func<Model, bool>> predicate = null
        )
        {
            return await Task.FromResult(new Result());
        }

        public override async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await Task.FromResult(Guid.Empty);
        }
    }

    public abstract class BaseUpdateCommand<Model, Repository, Update, Convertor, Validator>
        : BaseUpdateCommand<Model, Repository, Update, Validator>,
            IBaseUpdateCommand<Model, Update>
        where Update : UpdateDto
        where Model : TableModel
        where Convertor : IBaseUpdateConvertor<Model, Update>
        where Validator : IBaseUpdateValidator<Model, Update>
        where Repository : IBaseRepository<Model>
    {
        protected readonly Validator _validator;
        protected readonly Convertor _convertor;
        private readonly ICodeBookRepository<CultureDbo> _culture;

        public BaseUpdateCommand(Repository repository, Convertor convertor, Validator validator)
            : base(repository)
        {
            _validator = validator;
            _convertor = convertor;
        }

        public BaseUpdateCommand(Repository repository, Convertor convertor, Validator validator, ICodeBookRepository<CultureDbo> culture)
            : base(repository)
        {
            _validator = validator;
            _convertor = convertor;
            _culture = culture;
        }

        /// <summary>
        /// update object
        /// </summary>
        /// <param name="update"></param>
        /// <param name="userId"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public override async Task<Result> Execute(Update update, Guid userId, string culture, Result result = null)
        {
            if (_culture != null)
            {
                update.CultureId = (await _culture.GetEntity(false, x => x.SystemIdentificator == culture)).Id;
            }
            Model oldEntity = await _repository.GetEntity(update.Id) ?? throw new KeyNotFoundException(update.Id.ToString());
            result ??= await _validator.IsValid(update);
            if (result.IsOk)
            {
                Model entity = await _convertor.ConvertToBussinessEntity(update, oldEntity, culture);
                if (IsChanged(await _repository.GetEntity(update.Id), update, culture))
                {
                    _ = await _repository.UpdateEntity(entity, userId);
                    result.DataChanged = true;
                }
            }
            return result;
        }

        public override async Task<Result> Execute(
            Update update,
            Guid userId,
            string culture,
            Result result = null,
            Expression<Func<Model, bool>> predicate = null
        )
        {
            Result outData = new();
            List<Model> entities = await _repository.GetEntities(false, predicate);
            foreach (Model entity in entities)
            {
                update.Id = entity.Id;
                Result outuput = await Execute(update, userId, culture, null);
                if (outuput.IsError)
                {
                    outData.AddResultStatus(outData.Errors);
                }
            }
            return outData;
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

        public override async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await _repository.GetOrganizationId(objectId);
        }
    }
}
