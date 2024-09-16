using Core.Base.Convertor;
using Core.Base.Dto;
using Core.Base.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Command.Detail
{
    public abstract class BaseDetailCommand<TModel, TRepository, TDetail> : IBaseDetailCommand<TModel, TDetail>
        where TDetail : DetailDto
        where TModel : TableModel
        where TRepository : IBaseRepository<TModel>
    {
        protected readonly TRepository _repository;

        public BaseDetailCommand(TRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// get object detail
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public virtual async Task<TDetail> Execute(Guid objectId, List<string> culture)
        {
            return await Task.FromResult<TDetail>(null);
        }

        /// <summary>
        /// get object detail by condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public virtual async Task<TDetail> Execute(Expression<Func<TModel, bool>> predicate, List<string> culture, Dictionary<string, object> replace = null)
        {
            return await Task.FromResult<TDetail>(null);
        }

        public virtual async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await _repository.GetOrganizationId(objectId);
        }
    }

    public abstract class BaseDetailCommand<TModel, TRepository, TDetail, TConvertor> : BaseDetailCommand<TModel, TRepository, TDetail>
        where TDetail : DetailDto
        where TModel : TableModel
        where TRepository : IBaseRepository<TModel>
        where TConvertor : IBaseDetailConvertor<TModel, TDetail>
    {
        protected readonly TConvertor _convertor;

        public BaseDetailCommand(TRepository repository, TConvertor convertor)
            : base(repository)
        {
            _convertor = convertor;
        }

        /// <summary>
        /// get object detail
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override async Task<TDetail> Execute(Guid objectId, List<string> culture)
        {
            TModel model = await _repository.GetEntity(objectId);
            TDetail detail = await _convertor.ConvertToWebModel(model, culture);
            return detail;
        }

        /// <summary>
        /// get object detail by condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override async Task<TDetail> Execute(Expression<Func<TModel, bool>> predicate, List<string> culture, Dictionary<string, object> replace = null)
        {
            TModel entity = await _repository.GetEntity(false, predicate);
            if (entity == null)
            {
                return null;
            }
            TDetail detail = await _convertor.ConvertToWebModel(entity, culture);
            return detail;
        }

        public override async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await _repository.GetOrganizationId(objectId);
        }
    }
}
