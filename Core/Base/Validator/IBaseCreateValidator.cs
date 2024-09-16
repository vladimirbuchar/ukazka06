using Core.Base.Dto;
using Core.DataTypes;
using Model;
using System.Threading.Tasks;

namespace Core.Base.Validator
{


    public interface IBaseCreateValidator<Model, Create> : IBaseValidator
        where Model : TableModel
        where Create : CreateDto
    {
        Task<ResultInsert> IsValid(Create create);
    }
}
