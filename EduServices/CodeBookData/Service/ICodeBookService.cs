using System.Collections.Generic;
using Core.Base.Service;
using Services.CodeBookData.Dto;

namespace Services.CodeBookData.Service
{
    public interface ICodeBookService : IBaseService
    {
        HashSet<CodeBookListDto> GetCodeBookItems(string codeBookName, bool isLogged);
    }
}
