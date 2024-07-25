using Core.Base.Dto;
using Core.DataTypes;
using Model;
using System;
using System.Threading.Tasks;

namespace Core.Base.Service.Create
{
    public interface IBaseServiceCreate<Model, Create> : IBaseServiceNew
        where Create : CreateDto
        where Model : TableModel
    {
        Task<Result> Execute(Create addObject, Guid userId, string culture);
    }

}
