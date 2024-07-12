using Core.Base.Service;
using Services.CodeBookData.Dto;
using System.Collections.Generic;

namespace Services.CodeBookData.Service
{
    public interface ICodebookService : IBaseService
    {
        List<CodeBookListDto> GetCodeBookItems(string codeBookName, bool isLogged);
    }
}
