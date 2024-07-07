using System.Collections.Generic;
using System.Linq;
using Model.CodeBook;
using Services.CodeBookData.Dto;

namespace Services.CodeBookData.Convertor
{
    public class CodeBookConvertor : ICodeBookConvertor
    {
        public HashSet<CodeBookListDto> ConvertToWebModel<T>(HashSet<T> codebookItems)
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
                .ToHashSet();
        }
    }
}
