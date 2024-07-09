using System.Collections.Generic;
using System.Linq;
using Model.CodeBook;
using Services.CodeBookData.Dto;

namespace Services.CodeBookData.Convertor
{
    public class CodeBookConvertor : ICodeBookConvertor
    {
        public List<CodeBookListDto> ConvertToWebModel<T>(List<T> codebookItems)
            where T : CodeBook
        {
            return codebookItems
                .Select(item => new CodeBookListDto()
                {
                    Id = item.Id,
                    IsDefault = item.IsDefault,
                    Name = item.Name,
                    SystemIdentificator = item.SystemIdentificator
                })
                .ToList();
        }
    }
}
