using System.Collections.Generic;
using Core.Base.Convertor;
using Model.CodeBook;
using Services.CodeBookData.Dto;

namespace Services.CodeBookData.Convertor
{
    public interface ICodeBookConvertor : IBaseConvertor
    {
        HashSet<CodeBookListDto> ConvertToWebModel<T>(HashSet<T> codebookItems)
            where T : CodeBook;
    }
}
