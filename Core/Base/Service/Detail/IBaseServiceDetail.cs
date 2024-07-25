using Core.Base.Dto;
using Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Service.Detail
{
    public interface IBaseServiceDetail<Model, Detail> : IBaseServiceNew
        where Detail : DetailDto
        where Model : TableModel
    {
        Task<Detail> Execute(Guid objectId, string culture);
        Task<Detail> Execute(Expression<Func<Model, bool>> predicate, string culture);
    }

}
