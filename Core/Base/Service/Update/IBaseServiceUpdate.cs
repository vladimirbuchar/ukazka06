using Core.Base.Dto;
using Core.DataTypes;
using Model;
using System;
using System.Threading.Tasks;

namespace Core.Base.Service.Update
{
    public interface IBaseServiceUpdate<Model, Update, Detail> : IBaseServiceNew
        where Update : UpdateDto
        where Detail : DetailDto
        where Model : TableModel
    {
        Task<Result<Detail>> Execute(Update update, Guid userId, string culture, Result<Detail> result = null);
    }

}
