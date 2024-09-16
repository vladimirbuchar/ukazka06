using Core.Base.Dto;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Base.Convertor
{

    public interface IBaseDetailConvertor<Model, Detail> : IBaseConvertor
        where Model : TableModel
        where Detail : DetailDto
    {
        Task<Detail> ConvertToWebModel(Model detail, List<string> culture);
    }
}
