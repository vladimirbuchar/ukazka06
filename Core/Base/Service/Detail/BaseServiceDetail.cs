using Core.Base.Convertor;
using Core.Base.Dto;
using Core.Base.Repository;
using Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Service.Detail
{
    public abstract class BaseServiceDetail<Model, Repository, Detail, Convertor> : IBaseServiceDetail<Model, Detail>
        where Detail : DetailDto
        where Model : TableModel
        where Repository : IBaseRepository<Model>
        where Convertor : IBaseConvertorDetail<Model, Detail>


    {
        private readonly Repository _repository;
        private readonly Convertor _convertor;

        public BaseServiceDetail(Repository repository, Convertor convertor)
        {
            _repository = repository;
            _convertor = convertor;
        }


        /// <summary>
        /// get object detail
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public virtual async Task<Detail> Execute(Guid objectId, string culture)
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
        public virtual async Task<Detail> Execute(Expression<Func<Model, bool>> predicate, string culture)
        {
            Model entity = await _repository.GetEntity(false, predicate);
            Detail detail = await _convertor.ConvertToWebModel(entity, culture);
            return detail;
        }
    }


}
