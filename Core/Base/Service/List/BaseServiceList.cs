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
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Core.Base.Service.List
{
    public abstract class BaseServiceList<Model, Repository, ObjectList, Convertor, Filter> : IBaseServiceList<Model, ObjectList, Filter>
        where ObjectList : ListDto
        where Model : TableModel
        where Filter : FilterRequest
        where Repository : IBaseRepository<Model>
        where Convertor : IBaseConvertorList<Model, ObjectList>
    {
        private readonly Repository _repository;
        private readonly Convertor _convertor;
        public BaseServiceList(Repository repository, Convertor convertor)
        {
            _repository = repository;
            _convertor = convertor;
        }
        public virtual async Task<ResultTable<ObjectList>> Execute(
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
        public async Task<ResultTable<ObjectList>> Execute(string culture = "", Filter filter = null)
        {
            return await Execute(null, false, culture, filter);
        }

        public virtual async Task<ResultTable<ObjectList>> Execute(bool deleted = false, string culture = "")
        {
            return await Execute(null, deleted, culture);
        }

        public virtual async Task<ResultTable<ObjectList>> Execute()
        {
            return await Execute(null, false, string.Empty);
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
    }


}
