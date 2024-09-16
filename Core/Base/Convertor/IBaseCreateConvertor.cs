using Core.Base.Dto;
using Model;
using System.Threading.Tasks;

namespace Core.Base.Convertor
{
    public interface IBaseCreateConvertor<Model, Create> : IBaseConvertor
        where Model : TableModel
        where Create : CreateDto
    {
        Task<Model> ConvertToBussinessEntity(Create create, string culture);
    }
}
