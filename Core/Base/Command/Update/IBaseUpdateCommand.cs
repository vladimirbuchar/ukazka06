using Core.Base.Dto;
using Core.DataTypes;
using Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Command.Update
{
    public interface IBaseUpdateCommand<Model, Update> : IBaseCommand
        where Update : UpdateDto
        where Model : TableModel
    {
        Task<Result> Execute(Update update, Guid userId, string culture, Result result = null);
        Task<Result> Execute(Update update, Guid userId, string culture, Result result = null, Expression<Func<Model, bool>> predicate = null);
        Task<Guid> GetOrganizationIdByObjectId(Guid objectId);
    }
}
