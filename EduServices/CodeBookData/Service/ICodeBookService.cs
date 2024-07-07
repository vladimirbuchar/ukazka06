using Core.Base.Service;
using Services.CodeBookData.Dto;
using System.Collections.Generic;

namespace Services.CodeBookData.Service
{
    public interface ICodeBookService : IBaseService
    {
        HashSet<CodeBookItemListDto> GetCodeBookItems(string codeBookName, bool isLogged);
    }
}
