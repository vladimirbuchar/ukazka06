using Core.Base.Dto;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Base.Convertor
{
    public interface IBaseDropDownConvertor<Model, DropDown> : IBaseConvertor
        where Model : TableModel
        where DropDown : DropDownDto
    {
        Task<List<DropDown>> ConvertToWebModel(List<Model> list, List<string> culture);
    }
}
