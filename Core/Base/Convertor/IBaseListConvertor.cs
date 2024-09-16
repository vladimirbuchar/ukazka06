using Core.Base.Dto;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Base.Convertor
{
    public interface IBaseListConvertor<Model, ObjectList> : IBaseConvertor
        where Model : TableModel
        where ObjectList : ListDto
    {
        Task<List<ObjectList>> ConvertToWebModel(List<Model> list, List<string> culture);
    }
}
