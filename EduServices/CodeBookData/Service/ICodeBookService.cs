using Core.Base.Service;
using Services.CodeBookData.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CodeBookData.Service
{
    public interface ICodebookService : IBaseService
    {
        Task<List<CodeBookListDto>> GetCodeBookItems(string codeBookName, bool isLogged);
    }
}
