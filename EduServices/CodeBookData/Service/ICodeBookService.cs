using System.Collections.Generic;
using Core.Base.Service;
using Services.CodeBookData.Dto;

namespace Services.CodeBookData.Service
{
    public interface ICodeBookService : IBaseService
    {
        List<CodeBookListDto> GetCodeBookItems(string codeBookName, bool isLogged);
    }
}
