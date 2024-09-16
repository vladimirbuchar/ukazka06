using Core.Base.Dto;
using Core.Base.Sort;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Command.DropDown
{
    public interface IBaseDropDownCommand<Model, DropDown> : IBaseCommand
        where DropDown : DropDownDto
        where Model : TableModel
    {
        Task<List<DropDown>> Execute(
            Expression<Func<Model, bool>> predicate = null,
            bool deleted = false,
            List<string> culture = null,
            List<BaseSort<Model>> baseSorts = null,
            bool addDefaultValue = false,
            Expression<Func<Model, bool>> customPredicate = null


        );
        Task<Guid> GetOrganizationIdByParentId(Guid objectId);

    }
}
