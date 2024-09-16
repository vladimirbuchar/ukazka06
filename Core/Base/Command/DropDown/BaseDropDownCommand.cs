using Core.Base.Convertor;
using Core.Base.Dto;
using Core.Base.Repository;
using Core.Base.Sort;
using Core.Constants;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Command.DropDown
{
    public abstract class BaseDropDownCommand<TModel, TRepository, TDropDownList, TConvertor>(TRepository repository, TConvertor convertor) : IBaseDropDownCommand<TModel, TDropDownList>
        where TDropDownList : DropDownDto, new()
        where TModel : TableModel

        where TRepository : IBaseRepository<TModel>
        where TConvertor : IBaseDropDownConvertor<TModel, TDropDownList>
    {
        protected readonly TRepository _repository = repository;
        protected readonly TConvertor _convertor = convertor;

        public virtual async Task<List<TDropDownList>> Execute(
            Expression<Func<TModel, bool>> predicate = null,
            bool deleted = false,
            List<string> culture = null,
            List<BaseSort<TModel>> baseSorts = null,
            bool addDefaultValue = false,
            Expression<Func<TModel, bool>> customPredicate = null

        )
        {
            List<TModel> entities = await _repository.GetEntitiesDropDown(
                deleted,
                predicate,
                baseSorts,
                customPredicate
            );
            List<TDropDownList> data = await _convertor.ConvertToWebModel(entities, culture);
            if (addDefaultValue)
            {
                data.Insert(0, new TDropDownList()
                {
                    Id = Guid.Empty,
                    Name = CodebookValue.CODEBOOK_SELECT_VALUE,
                    IsDefault = true,
                });
            }
            return data;
        }

        public virtual async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await Task.FromResult(Guid.Empty);
        }

    }
}
