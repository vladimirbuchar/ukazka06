using Core.Base.Dto;
using Model;
using System.Threading.Tasks;

namespace Core.Base.Convertor
{
    public interface IBaseUpdateConvertor<Model, Update> : IBaseConvertor
        where Model : TableModel
        where Update : UpdateDto
    {
        Task<Model> ConvertToBussinessEntity(Update update, Model entity, string culture);
    }
}
