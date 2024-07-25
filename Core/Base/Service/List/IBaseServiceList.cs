using Core.Base.Dto;
using Core.Base.Filter;
using Core.Base.Paging;
using Core.DataTypes;
using Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Core.Base.Service.List
{
    public interface IBaseServiceList<Model, ObjectList, Filter> : IBaseServiceNew
        where ObjectList : ListDto
        where Model : TableModel
        where Filter : FilterRequest
    {
        Task<ResultTable<ObjectList>> Execute(
            Expression<Func<Model, bool>> predicate = null,
            bool deleted = false,
            string culture = "",
            Filter filter = null,
            string sortColumn = "",
            SortDirection sortDirection = SortDirection.Ascending,
            BasePaging paging = null
        );
        Task<ResultTable<ObjectList>> Execute();
        Task<ResultTable<ObjectList>> Execute(string culture = "", Filter filter = null);
        Task<ResultTable<ObjectList>> Execute(bool deleted = false, string culture = "");
    }

}
