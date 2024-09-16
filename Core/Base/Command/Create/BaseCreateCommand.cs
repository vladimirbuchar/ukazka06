using Core.Base.Convertor;
using Core.Base.Dto;
using Core.Base.Repository;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.DataTypes;
using Model;
using Model.CodeBook;
using System;
using System.Threading.Tasks;

namespace Core.Base.Command.Create
{
    public abstract class BaseCreateCommand<TModel, TRepository, TCreate>(TRepository repository) : BaseCommand<TRepository>(repository), IBaseCreateCommand<TModel, TCreate>
        where TCreate : CreateDto
        where TModel : TableModel
        where TRepository : IBaseRepository<TModel>
    {
        public virtual async Task<ResultInsert> Execute(TCreate addObject, Guid userId, string culture)
        {
            return await Task.FromResult(new ResultInsert());
        }

        public virtual async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await Task.FromResult(Guid.Empty);
        }

        public virtual async Task<ResultInsert> IsValid(TCreate create)
        {
            return await Task.FromResult(new ResultInsert());
        }
    }

    public abstract class BaseCreateCommand<TModel, TRepository, TCreate, TValidator>
        : BaseCreateCommand<TModel, TRepository, TCreate>,
            IBaseCreateCommand<TModel, TCreate>
        where TCreate : CreateDto
        where TModel : TableModel
        where TValidator : IBaseCreateValidator<TModel, TCreate>
        where TRepository : IBaseRepository<TModel>
    {
        protected readonly TValidator _validator;
        protected readonly ICodeBookRepository<CultureDbo> _culture;

        protected BaseCreateCommand(TRepository repository, TValidator validator)
            : base(repository)
        {
            _validator = validator;
        }

        protected BaseCreateCommand(TRepository repository, TValidator validator, ICodeBookRepository<CultureDbo> culture)
            : base(repository)
        {
            _validator = validator;
            _culture = culture;
        }

        public virtual async Task<ResultInsert> Execute(TCreate addObject, Guid userId, string culture)
        {
            return await Task.FromResult(new ResultInsert());
        }

        public virtual async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await Task.FromResult(Guid.Empty);
        }

        public virtual async Task<ResultInsert> IsValid(TCreate create)
        {
            return await _validator.IsValid(create);
        }
    }

    public abstract class BaseCreateCommand<TModel, TRepository, TCreate, TConvertor, TValidator>
        : BaseCreateCommand<TModel, TRepository, TCreate, TValidator>,
            IBaseCreateCommand<TModel, TCreate>
        where TCreate : CreateDto
        where TModel : TableModel
        where TConvertor : IBaseCreateConvertor<TModel, TCreate>
        where TValidator : IBaseCreateValidator<TModel, TCreate>
        where TRepository : IBaseRepository<TModel>
    {
        protected readonly TConvertor _convertor;

        public BaseCreateCommand(TRepository repository, TConvertor convertor, TValidator validator)
            : base(repository, validator)
        {
            _convertor = convertor;
        }

        public BaseCreateCommand(TRepository repository, TConvertor convertor, TValidator validator, ICodeBookRepository<CultureDbo> culture)
            : base(repository, validator, culture)
        {
            _convertor = convertor;
        }

        public override async Task<ResultInsert> Execute(TCreate addObject, Guid userId, string culture)
        {
            if (_culture != null)
            {
                addObject.CultureId = (await _culture.GetEntity(false, x => x.SystemIdentificator == culture)).Id;
            }
            ResultInsert result = await _validator.IsValid(addObject);
            if (result.IsOk)
            {
                TModel entity = await _convertor.ConvertToBussinessEntity(addObject, culture);
                result.InsertedId = (await _repository.CreateEntity(entity, userId)).Id;
            }
            return result;
        }
    }
}
