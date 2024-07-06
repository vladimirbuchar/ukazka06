using Core.Base.Convertor;
using EduServices.CodeBookData.Dto;
using Model.CodeBook;
using System.Collections.Generic;

namespace EduServices.CodeBookData.Convertor
{
    public interface ICodeBookConvertor : IBaseConvertor
    {
        HashSet<CodeBookItemListDto> ConvertToWebModel<T>(HashSet<T> codebookItems)
            where T : CodeBook;
    }
}
