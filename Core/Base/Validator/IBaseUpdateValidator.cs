using Core.Base.Dto;
using Core.DataTypes;
using Model;
using System.Threading.Tasks;

namespace Core.Base.Validator
{
    public interface IBaseUpdateValidator<Model, Update> : IBaseValidator
        where Model : TableModel
        where Update : UpdateDto
    {
        Task<Result> IsValid(Update update);
    }
}
