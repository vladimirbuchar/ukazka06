using Core.DataTypes;
using Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Service.MultipleDelete
{
    public interface IBaseServiceMultipleDelete<Model> : IBaseServiceNew
        where Model : TableModel
    {
        Task<Result> Execute(Expression<Func<Model, bool>> predicate, Guid userId);
    }

}
