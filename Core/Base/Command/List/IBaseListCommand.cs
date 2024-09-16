using Core.Base.Dto;
using Core.Base.Filter;
using Core.Base.Paging;
using Core.DataTypes;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Core.Base.Command.List
{
    public interface IBaseListCommand<Model, ObjectList, Filter> : IBaseCommand
        where ObjectList : ListDto
        where Model : TableModel
        where Filter : RequestFilter
    {
        Task<ResultTable<ObjectList>> Execute(
            Expression<Func<Model, bool>> predicate = null,
            bool deleted = false,
            List<string> culture = null,
            Filter filter = null,
            string sortColumn = "",
            SortDirection sortDirection = SortDirection.Ascending,
            BasePaging paging = null
        );
        Task<ResultTable<ObjectList>> Execute();
        Task<ResultTable<ObjectList>> Execute(List<string> culture = null, Filter filter = null);
        Task<ResultTable<ObjectList>> Execute(bool deleted = false, List<string> culture = null);
        Task<Guid> GetOrganizationIdByParentId(Guid objectId);
        Task<Guid> GetOrganizationIdByObjectId(Guid objectId);
    }
}
