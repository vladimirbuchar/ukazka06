using Core.Base.Dto;
using Core.DataTypes;
using Model;
using System;
using System.Threading.Tasks;

namespace Core.Base.Command.Create
{
    public interface IBaseCreateCommand<TModel, TCreate> : IBaseCommand
        where TCreate : CreateDto
        where TModel : TableModel
    {
        Task<ResultInsert> Execute(TCreate addObject, Guid userId, string culture);
        Task<ResultInsert> IsValid(TCreate create);
        Task<Guid> GetOrganizationIdByParentId(Guid objectId);
    }
}
