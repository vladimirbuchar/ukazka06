using Model;
using System;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace Core.Base.Sort
{
    public class BaseSort<Model> where Model : TableModel
    {
        public Expression<Func<Model, object>> Sort = null;
        public SortDirection SortDirection = SortDirection.Ascending;
    }
}
