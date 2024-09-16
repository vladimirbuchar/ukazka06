using Core.DataTypes;
using Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Command.MultipleDelete
{
    public interface IBaseMultipleDeleteCommand<Model> : IBaseCommand
        where Model : TableModel
    {
        Task<Result> Execute(Expression<Func<Model, bool>> predicate, Guid userId);
        Task<Guid> GetOrganizationIdByParentId(Guid objectId);
    }
}
