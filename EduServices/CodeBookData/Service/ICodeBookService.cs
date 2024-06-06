using Core.Base.Service;
using EduServices.CodeBookData.Dto;
using System.Collections.Generic;

namespace EduServices.CodeBookData.Service
{
    public interface ICodeBookService : IBaseService
    {
        HashSet<CodeBookItemListDto> GetCodeBookItems(string codeBookName);
    }
}
