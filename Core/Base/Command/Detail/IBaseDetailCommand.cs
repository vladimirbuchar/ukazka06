using Core.Base.Dto;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Command.Detail
{
    public interface IBaseDetailCommand<TModel, TDetail> : IBaseCommand
        where TDetail : DetailDto
        where TModel : TableModel
    {
        Task<TDetail> Execute(Guid objectId, List<string> culture);
        Task<TDetail> Execute(Expression<Func<TModel, bool>> predicate, List<string> culture, Dictionary<string, object> replace = null);
        Task<Guid> GetOrganizationIdByObjectId(Guid objectId);
    }
}
