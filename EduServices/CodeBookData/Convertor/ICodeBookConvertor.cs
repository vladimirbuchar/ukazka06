using Core.Base.Convertor;
using Model.CodeBook;
using Services.CodeBookData.Dto;
using System.Collections.Generic;

namespace Services.CodeBookData.Convertor
{
    public interface ICodeBookConvertor : IBaseConvertor
    {
        HashSet<CodeBookItemListDto> ConvertToWebModel<T>(HashSet<T> codebookItems)
            where T : CodeBook;
    }
}
